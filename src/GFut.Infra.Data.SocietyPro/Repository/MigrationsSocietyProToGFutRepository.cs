using GFut.Domain.Interfaces;
using GFut.Domain.Models;
using GFut.Infra.Data;
using GFut.Infra.Data.Context;
using GFut.Infra.Data.Repository;
using GFut.Infra.Data.SocietyPro.Model;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using static GFut.Domain.Others.Enum;

namespace GFut.Infra.Data.SocietyPro.Repository
{
    public class MigrationsSocietyProToGFutRepository : Repository<Horary>, IMigrationsSocietyProToGFutRepository
    {

        public int PessoaId = 0;
        public int CampoId = 0;
        public int CampeonatoId = 0;
        public int InscritoId = 0;
        public int JogadorId = 0;
        public int TimeId = 0;

        public MigrationsSocietyProToGFutRepository(AppDbContext context)
  : base(context)
        {

        }

        public void GetPessoa()
        {
            try
            {

                string sql = "";
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
                {
                    DataSource = "SQL5028.SmarterASP.NET",
                    UserID = "DB_9D81D5_societypro_admin",
                    Password = "darlan1510",
                    InitialCatalog = "DB_9D81D5_societypro"
                };

                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {

                    connection.Open();

                    sql = "select * from Pessoa where Status = 1";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        IDataReader dtreader = command.ExecuteReader();
                        DataTable dtresult = new DataTable();
                        dtresult.Load(dtreader);
                        dtreader.Close();

                        for (int i = 0; i < dtresult.Rows.Count; i++)
                        {
                            Person p = new Person
                            {
                                Active = true,
                                RegisterDate = Convert.ToDateTime(dtresult.Rows[i]["DATACADASTRO"].ToString()),
                                Name = dtresult.Rows[i]["NOME"].ToString(),
                                Cpf = "",
                                Rg = "",
                                BirthDate = Convert.ToDateTime(dtresult.Rows[i]["DATANASCIMENTO"].ToString()),
                                Phone = dtresult.Rows[i]["TELEFONE"].ToString(),
                                Email = dtresult.Rows[i]["EMAIL"].ToString(),
                                Picture = dtresult.Rows[i]["FOTO"].ToString(),
                                Password = dtresult.Rows[i]["SENHA"].ToString(),
                                Confirmation = true,
                                SecurityStamp = "",
                                IdPush = "",
                                Token = ""
                            };

                            Db.People.Add(p);
                            Db.SaveChanges();

                            using (SqlCommand command2 = new SqlCommand("select * from [dbo].[PESSOAPERFIL] where IDPESSOA = " + dtresult.Rows[i]["ID"].ToString(), connection))
                            {
                                using (SqlDataReader reader2 = command2.ExecuteReader())
                                {
                                    while (reader2.Read())
                                    {
                                        PersonProfile personProfile = new PersonProfile
                                        {
                                            Active = true,
                                            RegisterDate = Convert.ToDateTime(dtresult.Rows[i]["DATACADASTRO"].ToString()),
                                            ProfileType = (ProfileType)reader2.GetInt32(1) + 1,
                                            PersonId = p.Id
                                        };

                                        p.PersonProfiles.Add(personProfile);
                                    }
                                    reader2.Close();
                                }
                            }

                            int IdPessoaOld = Convert.ToInt32(dtresult.Rows[i]["ID"].ToString());

                            GetTime(p.Id, IdPessoaOld);
                            GetCampo(p.Id, IdPessoaOld);
                        }

                        Db.SaveChanges();
                    }

                }
            }
            catch (SqlException e)
            {
                // Attempt to roll back the transaction.
            }

        }
        public void GetTime(int IdNew, int IdOld)
        {
            try
            {

                string sql = "";
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
                {
                    DataSource = "SQL5028.SmarterASP.NET",
                    UserID = "DB_9D81D5_societypro_admin",
                    Password = "darlan1510",
                    InitialCatalog = "DB_9D81D5_societypro"
                };

                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {

                    connection.Open();

                    sql = "select * from Time  where Status = 1 AND IDPESSOA = " + IdOld;

                    using (SqlCommand command3 = new SqlCommand(sql, connection))
                    {
                        IDataReader dtreader3 = command3.ExecuteReader();
                        DataTable dtresult3 = new DataTable();
                        dtresult3.Load(dtreader3);
                        dtreader3.Close();

                        for (int X = 0; X < dtresult3.Rows.Count; X++)
                        {
                            Team t = new Team
                            {
                                Active = false,
                                RegisterDate = Convert.ToDateTime(dtresult3.Rows[X]["DATACADASTRO"].ToString()),
                                PersonId = IdNew,
                                Name = dtresult3.Rows[X]["NOME"].ToString(),
                                Symbol = dtresult3.Rows[X]["SIMBOLO"].ToString(),
                                Picture = dtresult3.Rows[X]["FOTO"].ToString(),
                                Type = 1,
                                Observation = dtresult3.Rows[X]["OBSERVACAO"].ToString(),
                                FundationDate = Convert.ToDateTime(dtresult3.Rows[X]["DATAFUNDACAO"].ToString()),
                                State = true
                            };

                            Db.Teams.Add(t);

                            int IdTimeOld = Convert.ToInt32(dtresult3.Rows[X]["ID"].ToString());

                            Db.SaveChanges();

                            GetJogador(t.Id, IdTimeOld);
                        }
                    }

                }
            }
            catch (SqlException e)
            {
                // Attempt to roll back the transaction.
            }
        }
        public void GetJogador(int IdNew, int IdOld)
        {
            try
            {

                string sql = "";
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
                {
                    DataSource = "SQL5028.SmarterASP.NET",
                    UserID = "DB_9D81D5_societypro_admin",
                    Password = "darlan1510",
                    InitialCatalog = "DB_9D81D5_societypro"
                };

                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {

                    connection.Open();

                    sql = "select  * from JOGADOR where status = 1 AND IDTIME = " + IdOld;

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        IDataReader dtreader = command.ExecuteReader();
                        DataTable dtresult = new DataTable();
                        dtresult.Load(dtreader);
                        dtreader.Close();

                        for (int i = 0; i < dtresult.Rows.Count; i++)
                        {
                            Player p = new Player
                            {
                                Active = true,
                                TeamId = IdNew,
                                Name = dtresult.Rows[i]["NOME"].ToString(),
                                BirthDate = Convert.ToDateTime(dtresult.Rows[i]["DATANASCIMENTO"].ToString()),
                                Picture = dtresult.Rows[i]["FOTO"].ToString(),
                                Position = (Position)Convert.ToInt32(dtresult.Rows[i]["POSICAO"].ToString()) + 1,
                                RegisterDate = Convert.ToDateTime(dtresult.Rows[i]["DATACADASTRO"].ToString()),
                                Dispensed = Convert.ToBoolean(dtresult.Rows[i]["DISPENSADO"].ToString()),
                                DispenseDate = Convert.ToDateTime(dtresult.Rows[i]["DATADISPENSA"].ToString()),
                                Phone = dtresult.Rows[i]["TELEFONE"].ToString()
                            };

                            Db.Players.Add(p);
                        }

                        Db.SaveChanges();
                    }

                }
            }
            catch (SqlException e)
            {
                // Attempt to roll back the transaction.
            }
        }
        public void GetCampo(int IDPESSOA, int IDPESSOAOld)
        {
            try
            {

                string sql = "";
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
                {
                    DataSource = "SQL5028.SmarterASP.NET",
                    UserID = "DB_9D81D5_societypro_admin",
                    Password = "darlan1510",
                    InitialCatalog = "DB_9D81D5_societypro"
                };

                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {

                    connection.Open();

                    sql = "select * from CAMPO where IDPESSOA = " + IDPESSOAOld;

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        IDataReader dtreader = command.ExecuteReader();
                        DataTable dtresult = new DataTable();
                        dtresult.Load(dtreader);
                        dtreader.Close();

                        for (int i = 0; i < dtresult.Rows.Count; i++)
                        {
                            Field c = new Field
                            {
                                Active = true,
                                RegisterDate = Convert.ToDateTime(dtresult.Rows[i]["DATACADASTRO"].ToString()),
                                Name = dtresult.Rows[i]["NOME"].ToString(),
                                Address = dtresult.Rows[i]["ENDERECO"].ToString(),
                                Phone = dtresult.Rows[i]["TELEFONE"].ToString(),
                                Value = Convert.ToDecimal(dtresult.Rows[i]["VALOR"].ToString()),
                                MonthlyValue = Convert.ToDecimal(dtresult.Rows[i]["VALORMENSAL"].ToString()),
                                Scheduled = Convert.ToBoolean(dtresult.Rows[i]["AGENDAMENTO"].ToString()),
                                Picture = dtresult.Rows[i]["LOGO"].ToString(),
                                PersonId = IDPESSOA,
                                CityId = 0
                            };

                            int FieldIdOld = Convert.ToInt32(dtresult.Rows[i]["ID"].ToString());

                            Db.Fields.Add(c);
                            Db.SaveChanges();

                            GetCampeonato(IDPESSOA, IDPESSOAOld, c.Id, FieldIdOld);
                            GetCampoItem(c.Id, FieldIdOld);
                        }
                    }

                }
            }
            catch (SqlException e)
            {
                // Attempt to roll back the transaction.
            }
        }
        public void GetCampoItem(int Id, int IdOld)
        {
            try
            {

                string sql = "";
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
                {
                    DataSource = "SQL5028.SmarterASP.NET",
                    UserID = "DB_9D81D5_societypro_admin",
                    Password = "darlan1510",
                    InitialCatalog = "DB_9D81D5_societypro"
                };

                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {

                    connection.Open();

                    sql = "select * from [dbo].[CAMPOITEM] where IDCAMPO = " + IdOld;

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        IDataReader dtreader = command.ExecuteReader();
                        DataTable dtresult = new DataTable();
                        dtresult.Load(dtreader);
                        dtreader.Close();

                        for (int i = 0; i < dtresult.Rows.Count; i++)
                        {
                            FieldItem c = new FieldItem
                            {
                                Active = true,
                                RegisterDate = DateTime.Now,
                                Name = dtresult.Rows[i]["DESCRICAO"].ToString(),
                                FieldId = Id
                            };

                            Db.FieldItens.Add(c);
                            Db.SaveChanges();

                            int IdItemOld = Convert.ToInt32(dtresult.Rows[i]["ID"].ToString());

                            GetCampoValor(c.Id, IdItemOld);
                            GetHorarioPadrao(c.Id, IdItemOld);
                            GetHorarioExtra(c.Id, IdItemOld);
                        }
                    }

                }
            }
            catch (SqlException e)
            {
                // Attempt to roll back the transaction.
            }
        }
        public void GetCampoValor(int Id, int IdOld)
        {
            try
            {

                string sql = "";
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
                {
                    DataSource = "SQL5028.SmarterASP.NET",
                    UserID = "DB_9D81D5_societypro_admin",
                    Password = "darlan1510",
                    InitialCatalog = "DB_9D81D5_societypro"
                };

                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {

                    connection.Open();

                    sql = "select * from [dbo].[CAMPOVALOR] where IDCAMPOITEM = " + IdOld;

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        IDataReader dtreader = command.ExecuteReader();
                        DataTable dtresult = new DataTable();
                        dtresult.Load(dtreader);
                        dtreader.Close();

                        for (int i = 0; i < dtresult.Rows.Count; i++)
                        {
                            HoraryPrice c = new HoraryPrice
                            {
                                Active = true,
                                RegisterDate = DateTime.Now,
                                FieldItemId = Id,
                                StartDate = Convert.ToDateTime(dtresult.Rows[i]["DATAINICIO"].ToString()),
                                Value = Convert.ToDecimal(dtresult.Rows[i]["VALOR"].ToString()),
                                MonthlyValue = Convert.ToDecimal(dtresult.Rows[i]["VALORMENSAL"].ToString())
                            };

                            Db.HoraryPrices.Add(c);
                            Db.SaveChanges();
                        }
                    }

                }
            }
            catch (SqlException e)
            {
                // Attempt to roll back the transaction.
            }
        }
        public void GetHorarioPadrao(int Id, int IdOld)
        {
            try
            {

                string sql = "";
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
                {
                    DataSource = "SQL5028.SmarterASP.NET",
                    UserID = "DB_9D81D5_societypro_admin",
                    Password = "darlan1510",
                    InitialCatalog = "DB_9D81D5_societypro"
                };

                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {

                    connection.Open();

                    sql = "select * from [dbo].[HORARIOPADRAO] where IDITEMCAMPO = " + IdOld;

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        IDataReader dtreader = command.ExecuteReader();
                        DataTable dtresult = new DataTable();
                        dtresult.Load(dtreader);
                        dtreader.Close();

                        for (int i = 0; i < dtresult.Rows.Count; i++)
                        {
                            Horary c = new Horary
                            {
                                Active = true,
                                State = true,
                                RegisterDate = DateTime.Now,
                                FieldItemId = Id,
                                Hour = dtresult.Rows[i]["HORARIO"].ToString().Trim(),
                                DayWeek = Convert.ToInt32(dtresult.Rows[i]["DIASEMANA"].ToString())
                            };

                            Db.Horarys.Add(c);
                            Db.SaveChanges();

                            int IdItemOld = Convert.ToInt32(dtresult.Rows[i]["ID"].ToString());

                            GetHorarioAgendamento(c.Id, IdItemOld);
                        }
                    }

                }
            }
            catch (SqlException e)
            {
                // Attempt to roll back the transaction.
            }
        }
        public void GetHorarioExtra(int Id, int IdOld)
        {
            try
            {

                string sql = "";
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
                {
                    DataSource = "SQL5028.SmarterASP.NET",
                    UserID = "DB_9D81D5_societypro_admin",
                    Password = "darlan1510",
                    InitialCatalog = "DB_9D81D5_societypro"
                };

                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {

                    connection.Open();

                    sql = "select * from [dbo].[HORARIOEXTRA] where IDITEMCAMPO = " + IdOld;

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        IDataReader dtreader = command.ExecuteReader();
                        DataTable dtresult = new DataTable();
                        dtresult.Load(dtreader);
                        dtreader.Close();

                        for (int i = 0; i < dtresult.Rows.Count; i++)
                        {
                            HoraryExtra c = new HoraryExtra
                            {
                                Active = true,
                                RegisterDate = DateTime.Now,
                                FieldItemId = Id,
                                Date = Convert.ToDateTime(dtresult.Rows[i]["data"].ToString()),
                                Hour = dtresult.Rows[i]["HORARIO"].ToString().Trim()
                            };

                            Db.HoraryExtras.Add(c);
                            Db.SaveChanges();
                        }
                    }

                }
            }
            catch (SqlException e)
            {
                // Attempt to roll back the transaction.
            }
        }
        public void GetHorarioAgendamento(int Id, int IdOld)
        {
            try
            {

                string sql = "";
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
                {
                    DataSource = "SQL5028.SmarterASP.NET",
                    UserID = "DB_9D81D5_societypro_admin",
                    Password = "darlan1510",
                    InitialCatalog = "DB_9D81D5_societypro"
                };

                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {

                    connection.Open();

                    sql = "select * from [dbo].[HORARIOAGENDADO] where IDHORARIO = " + IdOld;

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        IDataReader dtreader = command.ExecuteReader();
                        DataTable dtresult = new DataTable();
                        dtresult.Load(dtreader);
                        dtreader.Close();

                        for (int i = 0; i < dtresult.Rows.Count; i++)
                        {
                            Scheduling c = new Scheduling
                            {
                                Active = true,
                                RegisterDate = DateTime.Now,
                                HoraryId = Id,
                                Date = Convert.ToDateTime(dtresult.Rows[i]["DATA"].ToString()),
                                HoraryType = (HoraryType)1,
                                SchedulingType = (SchedulingType)1,
                                State = (StatusP)1,
                                CustomerNotRegistered = "GESSE",
                                Phone = dtresult.Rows[i]["TELEFONE"].ToString(),
                                MarkedApp = true
                            };

                            Db.Schedulings.Add(c);
                            Db.SaveChanges();
                        }
                    }

                }
            }
            catch (SqlException e)
            {
                // Attempt to roll back the transaction.
            }
        }






        public void GetCampeonato(int IDPESSOA, int IDPESSOAOld, int FieldId, int FieldIdOld)
        {
            try
            {

                string sql = "";
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
                {
                    DataSource = "SQL5028.SmarterASP.NET",
                    UserID = "DB_9D81D5_societypro_admin",
                    Password = "darlan1510",
                    InitialCatalog = "DB_9D81D5_societypro"
                };

                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {

                    connection.Open();

                    sql = "select c.* from [dbo].[Campeonato] c INNER JOIN CAMPO ca on c.iCodCampo = ca.Id where c.IDPESSOA = " + IDPESSOAOld + " AND ca.ID =" + FieldIdOld;

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        IDataReader dtreader = command.ExecuteReader();
                        DataTable dtresult = new DataTable();
                        dtresult.Load(dtreader);
                        dtreader.Close();

                        for (int i = 0; i < dtresult.Rows.Count; i++)
                        {
                            Championship c = new Championship
                            {
                                Active = true,
                                RegisterDate = Convert.ToDateTime(dtresult.Rows[i]["dDATACADASTRO"].ToString()),
                                Name = dtresult.Rows[i]["sNome"].ToString(),
                                StartDate = Convert.ToDateTime(dtresult.Rows[i]["dDataInicio"].ToString()),
                                EndDate = Convert.ToDateTime(dtresult.Rows[i]["dDataFim"].ToString()),
                                ChampionshipType = (ChampionshipType)Convert.ToInt32(dtresult.Rows[i]["iTipoCampeonato"].ToString()),
                                RefereeType = (RefereeType)Convert.ToInt32(dtresult.Rows[i]["iTipoArbitragem"].ToString()),
                                Type = Convert.ToInt32(dtresult.Rows[i]["TIPO"].ToString()),
                                FieldId = FieldId,
                                AmountTeam = Convert.ToInt32(dtresult.Rows[i]["iQuantidadeTimes"].ToString()),
                                ReleaseSubscription = false,
                                GoBack = false,
                                Picture = dtresult.Rows[i]["LOGO"].ToString(),
                                PersonId = IDPESSOA,
                                PlayerRegistration = false
                            };

                            Db.Championships.Add(c);
                        }

                        Db.SaveChanges();
                    }

                }
            }
            catch (SqlException e)
            {
                // Attempt to roll back the transaction.
            }
        }
        public void GetInscrito(int ChampionshipId, int TeamId, int ChampionshipIdOld, int TeamIdOld)
        {
            try
            {

                string sql = "";
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
                {
                    DataSource = "SQL5028.SmarterASP.NET",
                    UserID = "DB_9D81D5_societypro_admin",
                    Password = "darlan1510",
                    InitialCatalog = "DB_9D81D5_societypro"
                };

                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {

                    connection.Open();

                    sql = "select * from [dbo].[PreInscrito] p INNER JOIN [dbo].[Inscrito] i ON p.IDPreInscrito = i.IDPreInscrito where IDCampeonato =" + ChampionshipIdOld;
                    sql += " and IDTime =" + TeamIdOld;

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        IDataReader dtreader = command.ExecuteReader();
                        DataTable dtresult = new DataTable();
                        dtresult.Load(dtreader);
                        dtreader.Close();

                        for (int i = 0; i < dtresult.Rows.Count; i++)
                        {
                            Subscription c = new Subscription
                            {
                                Active = true,
                                RegisterDate = Convert.ToDateTime(dtresult.Rows[i]["dDataCadastro"].ToString()),
                                ChampionshipId = ChampionshipId,
                                TeamId = TeamId,
                                State = 'A',
                                ApprovedDate = Convert.ToDateTime(dtresult.Rows[i]["dDataCadastro"].ToString())
                            };

                            Db.Subscriptions.Add(c);
                        }

                        Db.SaveChanges();
                    }

                }
            }
            catch (SqlException e)
            {
                // Attempt to roll back the transaction.
            }
        }
        public void GetCampeonatoGrupo(int IDInscrito, int IDInscritoOld)
        {
            try
            {

                string sql = "";
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
                {
                    DataSource = "SQL5028.SmarterASP.NET",
                    UserID = "DB_9D81D5_societypro_admin",
                    Password = "darlan1510",
                    InitialCatalog = "DB_9D81D5_societypro"
                };

                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {

                    connection.Open();

                    sql = "select * from [dbo].[CampeonatoGrupo] where IDInscrito = " + IDInscritoOld;

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        IDataReader dtreader = command.ExecuteReader();
                        DataTable dtresult = new DataTable();
                        dtresult.Load(dtreader);
                        dtreader.Close();

                        for (int i = 0; i < dtresult.Rows.Count; i++)
                        {
                            GroupChampionship c = new GroupChampionship
                            {
                                Active = true,
                                RegisterDate = Convert.ToDateTime(dtresult.Rows[i]["dDataCadastro"].ToString()),
                                GroupId = (Group)Convert.ToInt32(dtresult.Rows[i]["IDGrupo"].ToString()),
                                SubscriptionId = IDInscrito
                            };

                            Db.GroupChampionships.Add(c);
                        }

                        Db.SaveChanges();
                    }

                }
            }
            catch (SqlException e)
            {
                // Attempt to roll back the transaction.
            }
        }
        public void GetJogadorInscrito(int JogadorId, int InscritoId, int JogadorIdOld, int InscritoIdOld)
        {
            try
            {

                string sql = "";
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
                {
                    DataSource = "SQL5028.SmarterASP.NET",
                    UserID = "DB_9D81D5_societypro_admin",
                    Password = "darlan1510",
                    InitialCatalog = "DB_9D81D5_societypro"
                };

                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {

                    connection.Open();

                    sql = "select * from [dbo].[JogadorInscrito] WHERE IDInscrito = " + InscritoIdOld;
                    sql += " and IDJogador =" + JogadorIdOld;


                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        IDataReader dtreader = command.ExecuteReader();
                        DataTable dtresult = new DataTable();
                        dtresult.Load(dtreader);
                        dtreader.Close();

                        for (int i = 0; i < dtresult.Rows.Count; i++)
                        {
                            PlayerRegistration c = new PlayerRegistration
                            {
                                Active = true,
                                RegisterDate = Convert.ToDateTime(dtresult.Rows[i]["dDataCadastro"].ToString()),
                                PlayerId = JogadorId,
                                SubscriptionId = InscritoId,
                                State = Convert.ToChar(dtresult.Rows[i]["STATUS"].ToString()),
                                ApprovedDate = Convert.ToDateTime(dtresult.Rows[i]["dDataCadastro"].ToString())
                            };

                            Db.PlayerRegistrations.Add(c);
                        }

                        Db.SaveChanges();
                    }

                }
            }
            catch (SqlException e)
            {
                // Attempt to roll back the transaction.
            }
        }
        public void GetPartidaCampeonato(int HomeSubscriptionId, int GuestSubscriptionId, int FieldItemId, int InscritoIdOld)
        {
            try
            {

                string sql = "";
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
                {
                    DataSource = "SQL5028.SmarterASP.NET",
                    UserID = "DB_9D81D5_societypro_admin",
                    Password = "darlan1510",
                    InitialCatalog = "DB_9D81D5_societypro"
                };

                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {

                    connection.Open();

                    sql = "select * from [dbo].[PartidaCampeonato] PC INNER JOIN [dbo].[Sumula] S ON PC.IDPartidaCampeonato = S.IDPartidaCampeonato where IDInscrito1 = " + InscritoIdOld;

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        IDataReader dtreader = command.ExecuteReader();
                        DataTable dtresult = new DataTable();
                        dtresult.Load(dtreader);
                        dtreader.Close();

                        for (int i = 0; i < dtresult.Rows.Count; i++)
                        {
                            MatchChampionship c = new MatchChampionship
                            {
                                Active = true,
                                RegisterDate = Convert.ToDateTime(dtresult.Rows[i]["dDataCadastro"].ToString()),
                                HomeSubscriptionId = HomeSubscriptionId,
                                GuestSubscriptionId = GuestSubscriptionId,
                                FieldItemId = FieldItemId,
                                HomePoints = Convert.ToInt32(dtresult.Rows[i]["iQntGols1"].ToString()),
                                GuestPoints = Convert.ToInt32(dtresult.Rows[i]["iQntGols2"].ToString()),
                                MatchDate = Convert.ToDateTime(dtresult.Rows[i]["dDataPartida"].ToString()),
                                StartTime = dtresult.Rows[i]["sHoraPartida"].ToString(),
                                Observation = dtresult.Rows[i]["sObservacao"].ToString(),
                                Calculate = Convert.ToBoolean(dtresult.Rows[i]["CLASSIFICACAO"].ToString()),
                                Round = Convert.ToInt32(dtresult.Rows[i]["iRodada"].ToString()),
                            };

                            Db.MatchChampionships.Add(c);
                        }

                        Db.SaveChanges();
                    }

                }
            }
            catch (SqlException e)
            {
                // Attempt to roll back the transaction.
            }
        }
        public void GetJogadorSumula(int MatchChampionshipId, int PlayerRegistrationId, int IDSumulaoLd, int IDJogadorInscritoold)
        {
            try
            {

                string sql = "";
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
                {
                    DataSource = "SQL5028.SmarterASP.NET",
                    UserID = "DB_9D81D5_societypro_admin",
                    Password = "darlan1510",
                    InitialCatalog = "DB_9D81D5_societypro"
                };

                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {

                    connection.Open();

                    sql = "select * from [dbo].[JogadorSumula] j INNER JOIN [dbo].[GolCampeonato] g ON j.IDJogadorSumula = g.iCodJogadorSumula  ";
                    sql += " INNER JOIN [dbo].[Cartao] c ON c.iCodJogadorSumula = j.IDJogadorSumula WHERE IDSumula = " + IDSumulaoLd + " AND IDJogadorInscrito = " + IDJogadorInscritoold;

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        IDataReader dtreader = command.ExecuteReader();
                        DataTable dtresult = new DataTable();
                        dtresult.Load(dtreader);
                        dtreader.Close();

                        for (int i = 0; i < dtresult.Rows.Count; i++)
                        {
                            MatchPlayerChampionship c = new MatchPlayerChampionship
                            {
                                Active = true,
                                RegisterDate = Convert.ToDateTime(dtresult.Rows[i]["dDataCadastro"].ToString()),
                                MatchChampionshipId = MatchChampionshipId,
                                PlayerRegistrationId = PlayerRegistrationId,
                                Number = Convert.ToInt32(dtresult.Rows[i]["iNumCamisa"].ToString()),
                                Points = Convert.ToInt32(dtresult.Rows[i]["iQuantidade"].ToString()),
                                Card = (CardType)Convert.ToInt32(dtresult.Rows[i]["iTipoCartao"].ToString()) + 1
                            };

                            Db.MatchPlayerChampionships.Add(c);
                        }

                        Db.SaveChanges();
                    }

                }
            }
            catch (SqlException e)
            {
                // Attempt to roll back the transaction.
            }
        }

    }
}


// CS5001.cs
// CS5001 expected when compiled with -target:exe or -target:winexe
public class Program
{
    // Uncomment the following line to resolve.
    static void Main() { }
}