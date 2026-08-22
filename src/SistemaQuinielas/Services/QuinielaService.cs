using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using SistemaQuinielas.Models;

namespace SistemaQuinielas.Services;

public class QuinielaService
{
    private readonly string RutaQuinielas = Path.Combine(
        Application.StartupPath, "Data", "quinielas.csv"
    );

    public List<Quiniela> ObtenerQuinielas()
    {
        List<Quiniela> quinielas = new List<Quiniela>();

        if (!File.Exists(RutaQuinielas)) return quinielas;

        using StreamReader lector = new StreamReader(RutaQuinielas);
        lector.ReadLine(); // Ignorar encabezado

        while (!lector.EndOfStream)
        {
            string? linea = lector.ReadLine();
            if (string.IsNullOrWhiteSpace(linea)) continue;

            string[] datos = linea.Split(';');
            if (datos.Length < 4) continue;

            Quiniela q = new Quiniela
            {
                Id = int.Parse(datos[0]),
                Nombre = datos[1],
                EsPrivada = bool.Parse(datos[2]),
                IdCreador = int.Parse(datos[3]),
                IdsUsuarios = new List<int>()
            };

            if (datos.Length >= 5 && !string.IsNullOrWhiteSpace(datos[4]))
            {
                string[] idsStr = datos[4].Split(',');
                foreach (string id in idsStr)
                {
                    q.IdsUsuarios.Add(int.Parse(id));
                }
            }

            quinielas.Add(q);
        }

        return quinielas;
    }

    public void GuardarQuinielas(List<Quiniela> quinielas)
    {
        using StreamWriter escritor = new StreamWriter(RutaQuinielas, false);
        escritor.WriteLine("Id;Nombre;EsPrivada;IdCreador;IdsUsuarios");

        foreach (Quiniela q in quinielas)
        {
            string usuarios = string.Join(",", q.IdsUsuarios);
            escritor.WriteLine($"{q.Id};{q.Nombre};{q.EsPrivada};{q.IdCreador};{usuarios}");
        }
    }

    public void CrearQuiniela(Quiniela nueva)
    {
        List<Quiniela> quinielas = ObtenerQuinielas();

        int nuevoId = 1;
        foreach (Quiniela q in quinielas)
        {
            if (q.Id >= nuevoId) nuevoId = q.Id + 1;
        }

        nueva.Id = nuevoId;

        if (!nueva.IdsUsuarios.Contains(nueva.IdCreador))
        {
            nueva.IdsUsuarios.Add(nueva.IdCreador);
        }

        quinielas.Add(nueva);
        GuardarQuinielas(quinielas);
    }

    public void UnirUsuarioAQuiniela(int idQuiniela, int idUsuario)
    {
        List<Quiniela> quinielas = ObtenerQuinielas();

        Quiniela? quinielaEncontrada = null;
        foreach (Quiniela q in quinielas)
        {
            if (q.Id == idQuiniela)
            {
                quinielaEncontrada = q;
                break;
            }
        }

        if (quinielaEncontrada == null)
        {
            throw new Exception("La quiniela no existe.");
        }

        if (!quinielaEncontrada.IdsUsuarios.Contains(idUsuario))
        {
            quinielaEncontrada.IdsUsuarios.Add(idUsuario);
            GuardarQuinielas(quinielas);
        }
    }
}