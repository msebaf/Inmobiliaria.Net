using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Inmobiliaria.Net.Models;

namespace Inmobiliaria.Net.Controllers
{
    public class ContratosController : Controller
    {
        public readonly BdContratos bdContratos = new BdContratos();
        // GET: Inmuebles
        public ActionResult Index()
        {   
            
            var contratos = bdContratos.GetContratos();
            return View(contratos);
        }

         public ActionResult Vigentes()
        {   
            
            var contratos = bdContratos.GetContratosVigentes();
            return View(contratos);
        }

        // GET: Inmuebles/Details/5
        public ActionResult Details(int id)
        {
            var contrato = bdContratos.GetContrato(id);
             BdPropietarios bdp = new BdPropietarios();
         
                 
            return View(contrato);
        }

        // GET: Inmuebles/Create
        public ActionResult Create()
        {
            BdInmuebles bdInmu = new BdInmuebles();
            BdInquilinos bdInqui = new BdInquilinos();
           
                 ViewBag.inmuebles = bdInmu.Getinmuebles();
                 ViewBag.inquilinos = bdInqui.Getinquilinos();
                 
            return View();
        }

        // POST: Inmuebles/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Contrato contrato)
        {
            
            try
            {
                // TODO: Add insert logic here
                int res = bdContratos.Alta(contrato);
                 DateTime? cuota = contrato.FechaInicio;
                BdPagos bdp = new BdPagos();
                while (cuota.Value.Month <= contrato.FechaFinal.Value.Month)
                {
                    Pago pago = new Pago{
                        ContratoId = res,
                       
                        Periodo = cuota.Value,
                        Monto = contrato.MontoMensual
                        

                    };
                   int pagoID = bdp.Alta(pago);
                    cuota = cuota.Value.AddMonths(1);
                }
               
                
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                 
                return View();
            }
        }

        // GET: Inmuebles/Edit/5
        public ActionResult Edit(int id)
        {
            var contrato = bdContratos.GetContrato(id);
            BdInmuebles bdInmu = new BdInmuebles();
            BdInquilinos bdInqui = new BdInquilinos();
            ViewBag.inmuebles = bdInmu.Getinmuebles();
            ViewBag.inquilinos = bdInqui.Getinquilinos();
            
            return View(contrato);
        }

        // POST: Inmuebles/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Contrato contrato)
        {
            try
            {
                // TODO: Add update logic here
                
                bdContratos.Actualizar(contrato);
                return RedirectToAction(nameof(Index));
                
            }
            catch
            {
           
                return View();
            }
        }

        // GET: Inmuebles/Delete/5
        public ActionResult Delete(int id)
        {
           var contrato =  bdContratos.GetContrato(id);
           BdInmuebles bdInmu = new BdInmuebles();
            BdInquilinos bdInqui = new BdInquilinos();
            ViewBag.inmueble = bdInmu.Getinmueble((int)contrato.InmuebleId);
            ViewBag.inquilino = bdInqui.Getinquilino((int)contrato.InquilinoId);
          
            return View(contrato);
        }

        // POST: Inmuebles/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Contrato contrato)
        {
            try
            {
                // TODO: Add delete logic here
                bdContratos.DeleteContrato(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
