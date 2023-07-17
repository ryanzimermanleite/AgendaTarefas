using AgendaTarefas.Data;
using AgendaTarefas.Models;
using AgendaTarefas.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace AgendaTarefas.Controllers
{
    public class TarefaController : Controller
    {
        private readonly ITarefaRepositorio _tarefaRepositorio;
        public TarefaController(ITarefaRepositorio tarefaRepositorio)
        {
            _tarefaRepositorio = tarefaRepositorio;
        }
        public IActionResult Index()
        {
            List<TarefaModel> tarefas = _tarefaRepositorio.BuscarTodos();

            return View(tarefas);
        }

        public IActionResult Lista()
        {
            List<ListaModel> horasdia = _tarefaRepositorio.ObterHorasDia();
            return View(horasdia);
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar(int Id)
        {
            TarefaModel contato = _tarefaRepositorio.ListarPorId(Id);
            return View(contato);
        }

        public IActionResult ApagarConfirmacao(int Id)
        {
            TarefaModel contato = _tarefaRepositorio.ListarPorId(Id);
            return View(contato);
        }
      
        public IActionResult Apagar(int Id)
        {
            try
            {
                bool apagado = _tarefaRepositorio.Apagar(Id);

                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Tarefa apagada com sucesso!";
                }
                else
                {
                    TempData["MensagemErro"] = "Ops, Não conseguimos apagar sua tarefa!";
                }

                return RedirectToAction("Index");
            }
            catch (System.Exception erro)
            {

                TempData["MensagemErro"] = $"Ops, Não conseguimos apagar sua tarefa!, mais detalhes do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Criar(TarefaModel tarefa)
        {
            TimeSpan diferenca = tarefa.Final - tarefa.Inicio;
            try
            {   if(diferenca.TotalHours > 5)
                {
                    TempData["MensagemErro"] = "O tempo máximo da tarefa cadastrada é de 5 horas!";
                    return RedirectToAction("Criar");
                }
                if(tarefa.Inicio.TimeOfDay > tarefa.Final.TimeOfDay)
                {
                    TempData["MensagemErro"] = "Não é permitido o cadastramento de tarefas com tempo sobreposto!";
                    return RedirectToAction("Criar");
                }
                var data = tarefa.Data.Date;
                var dataAtual = DateTime.Now.Date;

                var horarioInicio = tarefa.Inicio.TimeOfDay;
                var horarioAtual = DateTime.Now.TimeOfDay;     

                if (data == dataAtual && horarioInicio < horarioAtual || data < dataAtual) { 
                    TempData["MensagemErro"] = "Não é permitido o cadastramento de tarefas com início no passado!";
                    return RedirectToAction("Criar");
                }
                if(ModelState.IsValid)
                {

                    _tarefaRepositorio.Adicionar(tarefa);
                    TempData["MensagemSucesso"] = "Tarefa cadastrada com sucesso!";
                    return RedirectToAction("Index");

                }
                
                return View(tarefa);
            }
            catch (System.Exception erro)
            {

                TempData["MensagemErro"] = $"Ops, não conseguimos cadastrar sua tarefa!, tente novamente, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Alterar(TarefaModel tarefa)
        {
            TimeSpan diferenca = tarefa.Final - tarefa.Inicio;
            try
            {
                if (diferenca.TotalHours > 5)
                {
                    TempData["MensagemErro"] = "O tempo máximo da tarefa alterada é de 5 horas!";
                    return RedirectToAction("Editar");
                }
                if (tarefa.Inicio.TimeOfDay > tarefa.Final.TimeOfDay)
                {
                    TempData["MensagemErro"] = "Não é permitido o alteramento de tarefas com tempo sobreposto!";
                    return RedirectToAction("Editar");
                }

                var data = tarefa.Data.Date;
                var dataAtual = DateTime.Now.Date;

                var horarioInicio = tarefa.Inicio.TimeOfDay;
                var horarioAtual = DateTime.Now.TimeOfDay;
                //VALIDAR
                if (data == dataAtual && horarioInicio < horarioAtual || data < dataAtual)
                {
                    TempData["MensagemErro"] = "Não é permitido a alteração de tarefas com início no passado!";
                    return RedirectToAction("Criar");
                }

                if (ModelState.IsValid)
                {
                    _tarefaRepositorio.Atualizar(tarefa);
                    TempData["MensagemSucesso"] = "Tarefa alterada com sucesso!";
                    return RedirectToAction("Index");
                }

                return View("Editar", tarefa);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos atualizar sua tarefa!, tente novamente, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
