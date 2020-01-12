using Microsoft.EntityFrameworkCore;
using GFut.Domain.Models;
using GFut.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using GFut.Infra.Data.Context;
using static GFut.Domain.Others.Enum;

namespace GFut.Infra.Data.Repository
{
    public class SchedulingRepository : Repository<Scheduling>, ISchedulingRepository
    {

        public SchedulingRepository(AppDbContext context)
: base(context)
        {

        }

        //public IEnumerable<HoraryComplete> GetFieldScheduling(int idCampo, int idPessoa)
        //{
        //    IQueryable<int> hp = from p in Db.Horarys
        //                         where (p.FieldItem.IdField == idCampo)
        //                         select p.Id;

        //    IQueryable<int> he = from p in Db.HoraryExtras
        //                         where (p.FieldItem.IdField == idCampo)
        //                         select p.Id;

        //    List<Scheduling> hap = Db.Schedulings.Where(p => hp.Contains(p.IDHORARIO) && p.TIPOHORARIO == TipoHorario.Padrao && p.IDPESSOA == idPessoa).ToList();
        //    List<Scheduling> hae = Db.Schedulings.Where(p => he.Contains(p.IDHORARIO) && p.TIPOHORARIO == TipoHorario.Extra && p.IDPESSOA == idPessoa).ToList();

        //    List<HoraryComplete> listTotal = new List<HoraryComplete>();

        //    foreach (var item in hap)
        //    {
        //        HoraryComplete hpc = new HoraryComplete();

        //        hpc.ID = item.ID;
        //        hpc.DATA = item.DATA;

        //        if (item.STATUS == "A")
        //        {
        //            hpc.STATUS = "Aprovado";
        //        }
        //        else if (item.STATUS == "C")
        //        {
        //            hpc.STATUS = "Cancelado";
        //        }
        //        else if (item.STATUS == "P")
        //        {
        //            hpc.STATUS = "Pendente";
        //        }


        //        Horary h = Db.Horarys.Include(b => b.FieldItem).Include(b => b.FieldItem.Field).Where(b => b.Id == item.IDHORARIO).FirstOrDefault();

        //        hpc.HORA = h.Description;
        //        hpc.CAMPO = h.FieldItem.Name;
        //        hpc.LOGO = h.FieldItem.Field.Picture;
        //        hpc.VALOR = h.FieldItem.Field.Value;

        //        Person p = Db.People.Find(item.IDPESSOA);
        //        hpc.PESSOA = p.Name;
        //        hpc.TELEFONE = p.Fone;


        //        listTotal.Add(hpc);
        //    }

        //    foreach (var item in hae)
        //    {
        //        HoraryComplete hpc = new HoraryComplete();

        //        hpc.ID = item.ID;
        //        hpc.DATA = item.DATA;

        //        if (item.STATUS == "A")
        //        {
        //            hpc.STATUS = "Aprovado";
        //        }
        //        else if (item.STATUS == "C")
        //        {
        //            hpc.STATUS = "Cancelado";
        //        }
        //        else if (item.STATUS == "P")
        //        {
        //            hpc.STATUS = "Pendente";
        //        }

        //        HoraryExtra h = Db.HoraryExtras.Include(b => b.FieldItem).Include(b => b.FieldItem.Field).Where(b => b.Id == item.IDHORARIO).FirstOrDefault();

              
        //        hpc.HORA = h.Description;
        //        hpc.CAMPO = h.FieldItem.Name;
        //        hpc.LOGO = h.FieldItem.Field.Picture;
        //        hpc.VALOR = h.FieldItem.Field.Value;

        //        Person p = Db.People.Find(item.IDPESSOA);
        //        hpc.PESSOA = p.Name;
        //        hpc.TELEFONE = p.Fone;

        //        listTotal.Add(hpc);
        //    }

        //    return listTotal.OrderByDescending(p => p.DATA).ThenBy(p => p.HORA).ToList();
        //}

        //public IEnumerable<SchedulingAPI> GetHorary(int id, DateTime Data)
        //{
        //    List<SchedulingAPI> list = new List<SchedulingAPI>();
        //    int diaSemana = (int)Data.DayOfWeek;

        //    foreach (Horary item in Db.Horarys.Where(p => p.IdFieldItem == id && p.Active == true && p.DayWeek == diaSemana))
        //    {
        //        Scheduling agendados = Db.Schedulings.Where(p => p.DATA == Data && p.TIPOHORARIO == TipoHorario.Padrao && p.IDHORARIO == item.Id && p.STATUS != "C").FirstOrDefault();

        //        if (agendados == null)
        //        {
        //            SchedulingAPI newItem = new SchedulingAPI { ID = item.Id, HORARIO = item.Description.Trim(), TIPOHORARIO = TipoHorario.Padrao, AGENDADO = false };
        //            list.Add(newItem);
        //        }
        //        else
        //        {
        //            SchedulingAPI newItem = new SchedulingAPI { ID = item.Id, HORARIO = item.Description.Trim(), TIPOHORARIO = TipoHorario.Padrao, AGENDADO = true };
        //            list.Add(newItem);
        //        }
        //    }

        //    foreach (HoraryExtra item in Db.HoraryExtras.Where(p => p.IdFieldItem == id && p.Date == Data))
        //    {
        //        Scheduling agendados = Db.Schedulings.Where(p => p.DATA == Data && p.TIPOHORARIO == TipoHorario.Extra && p.IDHORARIO == item.Id && p.STATUS != "C").FirstOrDefault();

        //        if (agendados == null)
        //        {
        //            SchedulingAPI newItem = new SchedulingAPI { ID = item.Id, HORARIO = item.Description.Trim(), TIPOHORARIO = TipoHorario.Extra, AGENDADO = false };
        //            list.Add(newItem);
        //        }
        //        else
        //        {
        //            SchedulingAPI newItem = new SchedulingAPI { ID = item.Id, HORARIO = item.Description.Trim(), TIPOHORARIO = TipoHorario.Extra, AGENDADO = true };
        //            list.Add(newItem);
        //        }
        //    }

        //    return list;
        //}

        //public HoraryComplete GetTicket(int id)
        //{
        //    Scheduling hap = Db.Schedulings.Find(id);
        //    HoraryComplete hpc = new HoraryComplete();

        //    hpc.ID = hap.ID;
        //    hpc.DATA = hap.DATA;

        //    if (hap.STATUS == "A")
        //    {
        //        hpc.STATUS = "Aprovado";
        //    }
        //    else if (hap.STATUS == "C")
        //    {
        //        hpc.STATUS = "Cancelado";
        //    }
        //    else if (hap.STATUS == "P")
        //    {
        //        hpc.STATUS = "Pendente";
        //    }

        //    if (hap.TIPOHORARIO == TipoHorario.Padrao)
        //    {
        //        Horary hp = Db.Horarys.Include(b => b.FieldItem).Include(b => b.FieldItem.Field).Where(b => b.Id == hap.IDHORARIO).FirstOrDefault();

        //        hpc.HORA = hp.Description;
        //        hpc.CAMPO = hp.FieldItem.Name;
        //        hpc.LOGO = hp.FieldItem.Field.Picture;
        //        hpc.ENDERECO = hp.FieldItem.Field.Address;
        //        hpc.VALOR = hp.FieldItem.Field.Value;
        //        hpc.LOCAL = hp.FieldItem.Field.Name;
        //        hpc.TELEFONE = hp.FieldItem.Field.Fone;
        //    }
        //    else
        //    {
        //        HoraryExtra he = Db.HoraryExtras.Include(b => b.FieldItem).Include(b => b.FieldItem.Field).Where(b => b.Id == hap.IDHORARIO).FirstOrDefault();

        //        hpc.HORA = he.Description;
        //        hpc.CAMPO = he.FieldItem.Name;
        //        hpc.LOGO = he.FieldItem.Field.Picture;
        //        hpc.ENDERECO = he.FieldItem.Field.Address;
        //        hpc.VALOR = he.FieldItem.Field.Value;
        //        hpc.LOCAL = he.FieldItem.Field.Name;
        //        hpc.TELEFONE = he.FieldItem.Field.Fone;
        //    }

        //    Person p = Db.People.Find(hap.IDPESSOA);
        //    hpc.PESSOA = p.Name;

        //    return hpc;
        //}
    }
}
