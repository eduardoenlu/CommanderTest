using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Commander.Models;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;

namespace Commander.Data
{
    public class MySqlCommanderRepo : ICommanderRepo
    {
        private readonly CommanderContext _context;
        private readonly SqlHerramienta _sql;

        public MySqlCommanderRepo(CommanderContext context)
        {
            _context = context;
        }

        public MySqlCommanderRepo(SqlHerramienta sql)
        {
            _sql = sql;
        }

        public void CreateCommand(Command cmd)
        {
            if(cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }
            _context.Add(cmd);
        }

        public void DeleteCommand(Command cmd)
        {
            if(cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }
            _context.Commands.Remove(cmd);
        }

        public IEnumerable<Command> GetAppCommands()
        {
            return _context.Commands.ToList();
            
        }

        public Command GetCommandById(int id)
        {
            return _context.Commands.FirstOrDefault(p=> p.Id == id);
        }

        public bool SaveChanges()
        {
           return (_context.SaveChanges() >= 0);
        }

        public void UpdateCommand(Command cmd)
        {
            
        }

        public CommandModified GetCommandBySPId(int id)
        {
            return _context.pa_Command.FromSqlRaw($"CALL pa_Commands ({id});").ToList()[0];
        }

        public Command GetCommandByMysqlId(int id)
        {
            try
            {
                Command cmd = new Command();
                List<MySqlParameter> _Parametros = new List<MySqlParameter>();
                _Parametros.Add(new MySqlParameter("p_Command",id));
                _sql.PrepararProcedimiento("pa_Commands", _Parametros);
                DataTableReader DTR = _sql.EjecutarTableReader();
                while (DTR.Read())
                {
                    cmd.Id = int.Parse(DTR[0].ToString());
                    cmd.HowTo = DTR[1].ToString();
                    cmd.Line = DTR[2].ToString();
                    cmd.Platform = DTR[3].ToString();
                    // Resultado = JsonConvert.DeserializeObject<Command>(DTR[0].ToString());
                }

                return cmd;
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        public void Dispose()
        {
            _sql.Dispose();
        }
    }
}