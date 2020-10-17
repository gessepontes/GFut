using GFut.Application.Interfaces;
using GFut.Domain.Interfaces;
using System;
using System.Collections.Generic;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using GFut.Application.ViewModels;
using GFut.Domain.Models;
using Microsoft.AspNetCore.Hosting;
using System.Linq;
using static GFut.Domain.Others.Enum;
using GFut.Domain.Others;

namespace GFut.Application.Services
{
    public class MatchChampionshipAppService : IMatchChampionshipAppService
    {
        private readonly IMatchChampionshipRepository _matchChampionshipRepository;
        private readonly IChampionshipRepository _championshipRepository;
        private readonly ISubscriptionRepository _subscriptionRepository;
        private readonly IGroupChampionshipRepository _groupChampionshipRepository;
        private readonly IMapper _mapper;
        private readonly IHostingEnvironment _env;

        public MatchChampionshipAppService(IMapper mapper, IMatchChampionshipRepository matchChampionshipRepository, 
            ISubscriptionRepository subscriptionRepository, 
            IChampionshipRepository championshipRepository,
            IGroupChampionshipRepository groupChampionshipRepository,
            IHostingEnvironment env)
        {
            _matchChampionshipRepository = matchChampionshipRepository;
            _championshipRepository = championshipRepository;
            _subscriptionRepository = subscriptionRepository;
            _groupChampionshipRepository = groupChampionshipRepository;
            _mapper = mapper;
            _env = env;
        }

        public IEnumerable<MatchChampionshipViewModel> GetAll()
        {
            return _matchChampionshipRepository.GetAll().ProjectTo<MatchChampionshipViewModel>(_mapper.ConfigurationProvider);
        }

        public IEnumerable<MatchChampionshipViewModel> GetMatchChampionshipByChampionshipId(int id)
        {
            var _dados = _matchChampionshipRepository.GetAll().Where(p => p.HomeSubscription.ChampionshipId == id || p.GuestSubscription.ChampionshipId == id).ProjectTo<MatchChampionshipViewModel>(_mapper.ConfigurationProvider).ToList();

            _dados.ForEach(p => p.HomeSubscription = _subscriptionRepository.GetAll().Where(x => x.Id == p.HomeSubscriptionId).ProjectTo<SubscriptionViewModel>(_mapper.ConfigurationProvider).FirstOrDefault());

            return _dados.OrderBy(p => p.Round);
        }

        public MatchChampionshipViewModel GetById(int id)
        {
            return _mapper.Map<MatchChampionshipViewModel>(_matchChampionshipRepository.GetById(id));
        }

        public void Update(MatchChampionshipViewModel matchChampionshipViewModel)
        {
            _matchChampionshipRepository.Update(_mapper.Map<MatchChampionship>(matchChampionshipViewModel));
        }

        public void Remove(int id)
        {
            _matchChampionshipRepository.Remove(id);
        }

        public void AutomaticMatchChampionship(int championshipId, int groupId)
        {
            Random rnd = new Random();
            int quantityTeam = 0;
            int round = 0;
            int count = 0;
            int turno = 0;
            int fieldId = 0;

            List<int> teamSubscription = new List<int>();

            string[] matchs;
          

            var championship = _championshipRepository.GetById(championshipId);

            switch (championship.ChampionshipType)
            {
                case ChampionshipType.Grupos:
                    if (groupId == 0)
                    {
                        throw new Exception();
                    }
                    else
                    {
                        var groupChampionship = _groupChampionshipRepository.GetAll().Where(p => p.GroupId == (Group)groupId && p.Subscription.ChampionshipId == championshipId).ToList();

                        foreach (var e in groupChampionship)
                        {
                            teamSubscription.Add(e.SubscriptionId);
                            fieldId = e.Subscription.Championship.FieldId;
                        }
                    }
                    break;
                case ChampionshipType.MataMata:
                    break;
                case ChampionshipType.PontosCorridos:
                    var subscriptions = _subscriptionRepository.GetAll().Where(p => p.ChampionshipId == championshipId);

                    foreach (var e in subscriptions)
                    {
                        teamSubscription.Add(e.Id);
                        fieldId = e.Championship.FieldId;
                    }
                    break;
                default:
                    break;
            }

            quantityTeam = teamSubscription.Count();

            if (quantityTeam % 2 == 0) { round = quantityTeam - 1; } else { round = quantityTeam; }

            if (championship.GoBack)
            {
                turno = 2;
                matchs = new string[Divers.CalculaFatorial(quantityTeam) / Divers.CalculaFatorial(quantityTeam - 2)];
            }
            else
            {
                turno = 1;
                matchs = new string[Divers.CalculaFatorial(quantityTeam) / Divers.CalculaFatorial(quantityTeam - 2) / 2];
            }

            count = 0;

            for (int t = 0; t < turno; t++)
            {
                for (int i = 0; i < quantityTeam; i++)
                { //For para caminhar entre os times
                    for (int j = i; j < quantityTeam; j++)
                    { //For para caminha entre os adversários
                        if (teamSubscription[i] != teamSubscription[j])
                        {
                            MatchChampionship matchChampionship = new MatchChampionship
                            {
                                HomeSubscriptionId = teamSubscription[i],
                                GuestSubscriptionId = teamSubscription[j],
                                HomePoints = 0,
                                GuestPoints = 0,
                                MatchDate = DateTime.Now,
                                RegisterDate = DateTime.Now,
                                StartTime = "",
                                Round = 0
                            };

                            _matchChampionshipRepository.Add(matchChampionship);

                            //Sumula sumula = new Sumula();

                            //sumula.IDPartidaCampeonato = partidaCampeonato.IDPartidaCampeonato;
                            //sumula.sObservacao = "";
                            //sumula.dDataCadastro = DateTime.Now;
                            //db.Sumula.Add(sumula);
                            //db.SaveChanges();
                        }
                        }
                    }
                }

            if (quantityTeam % 2 == 0)
            {
                OrdenaRodada(championshipId, teamSubscription);
            }
            else
            {
                List<int> timesInscritosNew = new List<int>();

                foreach (int e in teamSubscription)
                {
                    timesInscritosNew[count] = e;
                    count++;
                }

                timesInscritosNew[teamSubscription.Count()] = 10000000;

                OrdenaRodada(championshipId, timesInscritosNew);
            }
        }

        public void OrdenaRodada(int championshipId, List<int> teamSubscription)
        {
            int teamId = 0;
            int round = 0;
            int exitWhile = 0;
            bool save = true;
            bool saveA = true;
            
            List<int> teamSubscriptionNew = new List<int>();

            for (int i = 0; i < teamSubscription.Count() - 1; i++)
            {
                teamId = teamSubscription[i];

                var matchChampionship = _matchChampionshipRepository.GetAll().Where(p => p.HomeSubscriptionId == teamId || p.GuestSubscriptionId == teamId);

                foreach (var e in matchChampionship)
                {
                    teamSubscriptionNew.Add(e.Id);
                }

                round = 1;

                for (int j = 0; j < teamSubscriptionNew.Count(); j++)
                {
                    var matchChampionshipAdd = _matchChampionshipRepository.GetById(teamSubscriptionNew[j]);


                    if (round > teamSubscriptionNew.Count())
                    {
                        round = 1;
                    }

                    if (matchChampionshipAdd != null)
                    {
                        if (matchChampionshipAdd.Round == 0)
                        {
                            save = true;
                            exitWhile = 0;

                            while (save)
                            {
                                List<MatchChampionship> lpc = _matchChampionshipRepository.GetAll().Where(p =>p.Round == round && (p.HomeSubscriptionId == teamId || p.GuestSubscriptionId == teamId)).ToList();

                                if (lpc.Count() == 0)
                                {
                                    saveA = true;

                                    while (saveA)
                                    {
                                        List<MatchChampionship> lpcA = new List<MatchChampionship>();

                                        if (teamId == matchChampionshipAdd.HomeSubscriptionId)
                                        {
                                            lpcA = _matchChampionshipRepository.GetAll().Where(p => p.Round == round && (p.HomeSubscriptionId == matchChampionshipAdd.GuestSubscriptionId || p.GuestSubscriptionId == matchChampionshipAdd.GuestSubscriptionId)).ToList();
                                        }
                                        else
                                        {
                                            lpcA = _matchChampionshipRepository.GetAll().Where(p => p.Round == round && (p.HomeSubscriptionId == matchChampionshipAdd.HomeSubscriptionId || p.GuestSubscriptionId == matchChampionshipAdd.HomeSubscriptionId)).ToList();
                                        }


                                        if (lpcA.Count() == 0)
                                        {
                                            matchChampionshipAdd.Round = round;
                                            _matchChampionshipRepository.Update(matchChampionshipAdd);

                                            saveA = false;
                                            save = false;
                                        }
                                        else
                                        {
                                            saveA = true;
                                            round++;

                                            if (round > teamSubscriptionNew.Count())
                                            {
                                                saveA = false;
                                                save = false;
                                                round = 0;
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    save = true;
                                    round++;

                                    if (round > teamSubscriptionNew.Count())
                                    {
                                        saveA = false;
                                        round = 0;
                                    }
                                }

                                exitWhile++;

                                if (exitWhile > 50)
                                {
                                    save = false;
                                }
                            }
                        }
                    }

                    round++;
                }
            }

        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public void Add(MatchChampionshipViewModel matchChampionshipViewModel)
        {
            _matchChampionshipRepository.Add(_mapper.Map<MatchChampionship>(matchChampionshipViewModel));
        }

        //public ActionResult GerarPartidasCampeonato(int? IDCampeonato, int? IDGrupoP)
        //{

        //    try
        //    {
        //        ViewBag.ListaCampeonato = db.Campeonato;

        //        CampeonatoGrupo campeonatoGrupo = new CampeonatoGrupo();
        //        IEnumerable<IDGrupo> actionTypes = Enum.GetValues(typeof(IDGrupo))
        //                                                   .Cast<IDGrupo>();
        //        ViewBag.ListaGrupos = from action in actionTypes
        //                              select new SelectListItem
        //                              {
        //                                  Text = action.ToString(),
        //                                  Value = ((int)action).ToString()
        //                              };

        //        Random rnd = new Random();
        //        int qtde_times = 0;
        //        //int iRodada = 1;
        //        //int iQntdJogoTimeRodada = 0;
        //        int iQntdRodadas = 0;
        //        int cont = 0;
        //        int turno = 0;
        //        int[] timesInscritos;
        //        string[] partidas;
        //        int IDCampo = 0;


        //        if (IDCampeonato == null)
        //        {
        //            return View().ComMensagem("Selecione o Campeonato.", "alert-warning");
        //        }
        //        else
        //        {
        //            var campeonato = db.Campeonato.Find(IDCampeonato);


        //            switch (campeonato.iTipoCampeonato)
        //            {
        //                case TipoCampeonato.Grupos:

        //                    if (IDGrupoP == null)
        //                    {
        //                        return View().ComMensagem("Selecione o grupo.", "alert-warning");
        //                    }
        //                    else
        //                    {
        //                        IDGrupo grupo = (IDGrupo)Enum.ToObject(typeof(IDGrupo), IDGrupoP);

        //                        var inscritosGrupos = db.CampeonatoGrupo.Where(p => p.IDGrupo == grupo && p.Inscrito.PreInscrito.IDCampeonato == IDCampeonato).ToList();

        //                        int[] timesGrupo = new int[inscritosGrupos.Count];

        //                        foreach (CampeonatoGrupo e in inscritosGrupos)
        //                        {
        //                            timesGrupo[cont] = e.IDInscrito;
        //                            IDCampo = e.Inscrito.PreInscrito.Campeonato.iCodCampo;
        //                            cont++;
        //                        }

        //                        timesInscritos = timesGrupo;
        //                    }
        //                    break;
        //                case TipoCampeonato.MataMata:
        //                    return View().ComMensagem("Regra do Mata-Mata não foi emplementada.", "alert-warning");
        //                default:

        //                    var inscritos = db.Inscrito.Where(p => p.PreInscrito.Campeonato.IDCampeonato == IDCampeonato).ToList();

        //                    int[] times = new int[inscritos.Count];

        //                    foreach (Inscrito e in inscritos)
        //                    {
        //                        times[cont] = e.IDInscrito;
        //                        IDCampo = e.PreInscrito.Campeonato.iCodCampo;
        //                        cont++;
        //                    }

        //                    timesInscritos = times;
        //                    break;
        //            }


        //            qtde_times = timesInscritos.Count(); // Quantidade de Times

        //            if (qtde_times % 2 == 0) { iQntdRodadas = qtde_times - 1; } else { iQntdRodadas = qtde_times; }

        //            if (campeonato.bIdaVolta)
        //            {
        //                turno = 2;
        //                partidas = new string[calculaFatorial(qtde_times) / calculaFatorial(qtde_times - 2)];
        //            }
        //            else
        //            {
        //                turno = 1;
        //                partidas = new string[calculaFatorial(qtde_times) / calculaFatorial(qtde_times - 2) / 2];
        //            }

        //            cont = 0;

        //            for (int t = 0; t < turno; t++)
        //            {
        //                for (int i = 0; i < qtde_times; i++)
        //                { //For para caminhar entre os times
        //                    for (int j = i; j < qtde_times; j++)
        //                    { //For para caminha entre os adversários
        //                        if (timesInscritos[i] != timesInscritos[j])
        //                        {

        //                            using (var transaction = db.Database.BeginTransaction())
        //                            {
        //                                try
        //                                {
        //                                    PartidaCampeonato partidaCampeonato = new PartidaCampeonato();
        //                                    partidaCampeonato.IDInscrito1 = timesInscritos[i];
        //                                    partidaCampeonato.IDInscrito2 = timesInscritos[j];
        //                                    partidaCampeonato.iQntGols1 = 0;
        //                                    partidaCampeonato.iQntGols2 = 0;
        //                                    partidaCampeonato.dDataPartida = DateTime.Now;
        //                                    partidaCampeonato.dDataCadastro = DateTime.Now;
        //                                    partidaCampeonato.sHoraPartida = "";
        //                                    partidaCampeonato.iRodada = "0";
        //                                    partidaCampeonato.IDCAMPO = IDCampo;

        //                                    db.PartidaCampeonato.Add(partidaCampeonato);
        //                                    db.SaveChanges();

        //                                    Sumula sumula = new Sumula();

        //                                    sumula.IDPartidaCampeonato = partidaCampeonato.IDPartidaCampeonato;
        //                                    sumula.sObservacao = "";
        //                                    sumula.dDataCadastro = DateTime.Now;
        //                                    db.Sumula.Add(sumula);
        //                                    db.SaveChanges();

        //                                    transaction.Commit();
        //                                }
        //                                catch (Exception ex)
        //                                {
        //                                    ex.Message.ToString();
        //                                    transaction.Rollback();
        //                                }
        //                            }
        //                        }
        //                    }
        //                }

        //            }

        //            if (qtde_times % 2 == 0)
        //            {
        //                OrdenaRodada(IDCampeonato ?? 0, timesInscritos);
        //            }
        //            else
        //            {
        //                int[] timesInscritosNew = new int[timesInscritos.Count() + 1];

        //                foreach (int e in timesInscritos)
        //                {
        //                    timesInscritosNew[cont] = e;
        //                    cont++;
        //                }

        //                timesInscritosNew[timesInscritos.Count()] = 10000000;

        //                OrdenaRodada(IDCampeonato ?? 0, timesInscritosNew);
        //            }

        //        }
        //    }
        //    catch (DbEntityValidationException dbEx)
        //    {
        //        foreach (var validationErrors in dbEx.EntityValidationErrors)
        //        {
        //            foreach (var validationError in validationErrors.ValidationErrors)
        //            {
        //                System.Console.WriteLine("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
        //            }
        //        }
        //        return View().ComMensagem("Erro ao realizar a operação.", "alert-danger");
        //    }

        //    return RedirectToAction("Index", new { IDCAMPEONATO = IDCampeonato }).ComMensagem("Operação realizada com sucesso.", "alert-success");

        //}


        //public void OrdenaRodada(int IDCampeonato, int[] timesInscritos)
        //{
        //    int cont = 0;
        //    int IDTime = 0;
        //    int rodada = 0;
        //    int sairWhile = 0;
        //    Boolean bSalvo = true;
        //    Boolean bSalvoA = true;
        //    int[] idPartidasTime = new int[timesInscritos.Count() - 1];

        //    for (int i = 0; i < timesInscritos.Count() - 1; i++)
        //    {

        //        cont = 0;
        //        IDTime = timesInscritos[i];

        //        foreach (PartidaCampeonato e in db.PartidaCampeonato.Where(p => p.IDInscrito1 == IDTime || p.IDInscrito2 == IDTime))
        //        {
        //            idPartidasTime[cont] = e.IDPartidaCampeonato;
        //            cont++;
        //        }

        //        rodada = 1;

        //        for (int j = 0; j < idPartidasTime.Count(); j++)
        //        {

        //            PartidaCampeonato partidaCampeonato = new PartidaCampeonato();
        //            partidaCampeonato = db.PartidaCampeonato.Find(idPartidasTime[j]);


        //            if (rodada > idPartidasTime.Count())
        //            {
        //                rodada = 1;
        //            }

        //            if (partidaCampeonato != null)
        //            {
        //                if (partidaCampeonato.iRodada == "0")
        //                {
        //                    bSalvo = true;
        //                    sairWhile = 0;

        //                    while (bSalvo)
        //                    {
        //                        List<PartidaCampeonato> lpc = db.PartidaCampeonato.Where(p => p.iRodada == rodada.ToString() && (p.IDInscrito1 == IDTime || p.IDInscrito2 == IDTime)).ToList();

        //                        if (lpc.Count() == 0)
        //                        {
        //                            bSalvoA = true;

        //                            while (bSalvoA)
        //                            {
        //                                List<PartidaCampeonato> lpcA = new List<PartidaCampeonato>();

        //                                if (IDTime == partidaCampeonato.IDInscrito1)
        //                                {
        //                                    lpcA = db.PartidaCampeonato.Where(p => p.iRodada == rodada.ToString() && (p.IDInscrito1 == partidaCampeonato.IDInscrito2 || p.IDInscrito2 == partidaCampeonato.IDInscrito2)).ToList();
        //                                }
        //                                else
        //                                {
        //                                    lpcA = db.PartidaCampeonato.Where(p => p.iRodada == rodada.ToString() && (p.IDInscrito1 == partidaCampeonato.IDInscrito1 || p.IDInscrito2 == partidaCampeonato.IDInscrito1)).ToList();
        //                                }


        //                                if (lpcA.Count() == 0)
        //                                {
        //                                    db.Entry(partidaCampeonato).State = EntityState.Modified;
        //                                    partidaCampeonato.iRodada = rodada.ToString();
        //                                    db.SaveChanges();
        //                                    bSalvoA = false;
        //                                    bSalvo = false;
        //                                }
        //                                else
        //                                {
        //                                    bSalvoA = true;
        //                                    rodada++;

        //                                    if (rodada > idPartidasTime.Count())
        //                                    {
        //                                        bSalvoA = false;
        //                                        bSalvo = false;
        //                                        rodada = 0;
        //                                    }
        //                                }
        //                            }
        //                        }
        //                        else
        //                        {
        //                            bSalvo = true;
        //                            rodada++;

        //                            if (rodada > idPartidasTime.Count())
        //                            {
        //                                bSalvoA = false;
        //                                rodada = 0;
        //                            }
        //                        }

        //                        sairWhile++;

        //                        if (sairWhile > 50)
        //                        {
        //                            bSalvo = false;
        //                        }
        //                    }
        //                }
        //            }

        //            rodada++;
        //        }
        //    }

        //}
    }
}
