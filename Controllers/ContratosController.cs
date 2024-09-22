using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Inmobiliaria.Net.Models;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;


namespace Inmobiliaria.Net.Controllers
{
    [Authorize]
    public class ContratosController : Controller
    {
        public readonly BdContratos bdContratos = new BdContratos();
        // GET: Inmuebles
        public ActionResult Index(int? id)
        {   
              var montoRescindido = TempData["MontoRescindido"];
                if (montoRescindido != null)
                {
                    ViewBag.MontoRescindido = montoRescindido.ToString();
                    Console.WriteLine($"Monto Rescindido: {montoRescindido}");
                }
                
                ViewBag.idInmueble = id;
            var contratos = bdContratos.GetContratos(id);
            return View(contratos);
        }

         public ActionResult Vigentes()
        {   
            
            var contratos = bdContratos.GetContratosVigentes();
           
        return View(contratos);
        }

        public ActionResult Vencidos()
        {   
            
            var contratos = bdContratos.GetContratosVencidos();
            return View(contratos);
        }


        // GET: Inmuebles/Details/5
        public ActionResult Details(int id)
        {
            var contrato = bdContratos.GetContrato(id);
             
         
                 
            return View(contrato);
        }

        // GET: Inmuebles/Create
        public ActionResult Create()
        {
            BdInmuebles bdInmu = new BdInmuebles();
            BdInquilinos bdInqui = new BdInquilinos();
           
                 ViewBag.inmuebles = bdInmu.GetInmueblesDisp();
                 ViewBag.inquilinos = bdInqui.Getinquilinos();
                 
            return View();
        }

        // POST: Inmuebles/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Contrato contrato)
        {
              var context = new ValidationContext(contrato, serviceProvider: null, items: null);
            var isValid = Validator.TryValidateObject(contrato, context, null, true);
            if(isValid){


                int conts = bdContratos.GetContratoCrearValidador(contrato.FechaInicio, contrato.FechaFinal, contrato.InmuebleId);
                if(conts==0){
                    Console.WriteLine(conts);
                
            try
            {
                // TODO: Add insert logic here
                int res = bdContratos.Alta(contrato);
                
                
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                 
                return View();
            }
            }else{
               Console.WriteLine(conts);
                ModelState.AddModelError("FechaFinal", "El inmueble no esta disponible en este periodo");
                
        
                  BdInmuebles bdInmu = new BdInmuebles();
            BdInquilinos bdInqui = new BdInquilinos();
                 ViewBag.inmuebles = bdInmu.Getinmuebles(null);
                 ViewBag.inquilinos = bdInqui.Getinquilinos();
                
                
                
                return View();
            }
            }else{
                BdInmuebles bdInmu = new BdInmuebles();
            BdInquilinos bdInqui = new BdInquilinos();
                 ViewBag.inmuebles = bdInmu.Getinmuebles(null);
                 ViewBag.inquilinos = bdInqui.Getinquilinos();
                
                
                
                return View();
            }
        }

        // GET: Inmuebles/Edit/5
        public ActionResult Edit(int id)
        {
            var contrato = bdContratos.GetContrato(id);
            BdInmuebles bdInmu = new BdInmuebles();
            BdInquilinos bdInqui = new BdInquilinos();
            ViewBag.inmuebles = bdInmu.Getinmuebles(null);
            ViewBag.inquilinos = bdInqui.Getinquilinos();
            
            return View(contrato);
        }

        // POST: Inmuebles/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Contrato contrato)
        {
             var context = new ValidationContext(contrato, serviceProvider: null, items: null);
            var isValid = Validator.TryValidateObject(contrato, context, null, true);
            if(isValid){
            int conts = bdContratos.GetContratoEditarValidador(contrato.FechaInicio, contrato.FechaFinal, contrato.InmuebleId, contrato.Id);
                if(conts==0){
                    
                
            try
            {
                // TODO: Add insert logic here
                int res = bdContratos.Actualizar(contrato);
                
                
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                 
                return View();
            }
            }else{
               
                ModelState.AddModelError("FechaFinal", "El inmueble no esta disponible en este periodo");
                
        
                  BdInmuebles bdInmu = new BdInmuebles();
            BdInquilinos bdInqui = new BdInquilinos();
                 ViewBag.inmuebles = bdInmu.Getinmuebles(null);
                 ViewBag.inquilinos = bdInqui.Getinquilinos();
                
                
                
                return View(contrato);
            }
            }else{
                  {
            
            BdInmuebles bdInmu = new BdInmuebles();
            BdInquilinos bdInqui = new BdInquilinos();
            ViewBag.inmuebles = bdInmu.Getinmuebles(null);
            ViewBag.inquilinos = bdInqui.Getinquilinos();
            
            return View(contrato);
        }
            }
        }

        // GET: Inmuebles/Delete/5
        [Authorize(Policy = "Administrador")]
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
        [Authorize(Policy = "Administrador")]
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
    

    
    public ActionResult Renovar(int Id, int inmuebleId)
        {
            BdInmuebles bdInmu = new BdInmuebles();
            BdInquilinos bdInqui = new BdInquilinos();
                List<Inmueble> inmuebles = new List<Inmueble>();;
              Inmueble  inmueble = bdInmu.Getinmueble(inmuebleId);
              Console.WriteLine(inmueble);
              inmuebles.Add(inmueble);
                 ViewBag.inmuebles = inmuebles;
                 ViewBag.inquilinos = bdInqui.Getinquilinos();
                 Contrato contrato = bdContratos.GetContrato(Id);
                 contrato.FechaInicio = contrato.FechaFinal.HasValue? contrato.FechaFinal.Value.AddDays(1) : DateTime.Now;;
                 contrato.FechaFinal = null;
                 
            return View(contrato);
        }

        // POST: Inmuebles/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Renovar(Contrato contrato)
        {
              var context = new ValidationContext(contrato, serviceProvider: null, items: null);
            var isValid = Validator.TryValidateObject(contrato, context, null, true);
            if(isValid){


                int conts = bdContratos.GetContratoRenovarValidador(contrato.FechaInicio, contrato.FechaFinal, contrato.InmuebleId);
                if(conts==0){
                    
                
            try
            {
                // TODO: Add insert logic here
                int res = bdContratos.Alta(contrato);
                
                
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                 
                return View();
            }
            }else{
               
                ModelState.AddModelError("FechaFinal", "El inmueble no esta disponible en este periodo");
                
        
                  BdInmuebles bdInmu = new BdInmuebles();
            BdInquilinos bdInqui = new BdInquilinos();
                 ViewBag.inmuebles = bdInmu.Getinmuebles(null);
                 ViewBag.inquilinos = bdInqui.Getinquilinos();
                
                
                
                return View();
            }
            }else{
                BdInmuebles bdInmu = new BdInmuebles();
            BdInquilinos bdInqui = new BdInquilinos();
                 ViewBag.inmuebles = bdInmu.Getinmuebles(null);
                 ViewBag.inquilinos = bdInqui.Getinquilinos();
                
                
                
                return View();
            }
        }



       
        public ActionResult AlquilarPorFechas(DateTime fechaInicio, DateTime fechaFinal, int inmuebleId)
        {
            BdInmuebles bdInmu = new BdInmuebles();
                List<Inmueble> inmuebles = new List<Inmueble>();;
              Inmueble  inmueble = bdInmu.Getinmueble(inmuebleId);
              Console.WriteLine(inmueble);
              inmuebles.Add(inmueble);
                 ViewBag.inmuebles = inmuebles;
                 Contrato contrato = new Contrato();
                 contrato.InmuebleId = inmuebleId;
                 contrato.FechaInicio = fechaInicio;
                 contrato.FechaFinal = fechaFinal;
                 BdInquilinos bdInqui = new BdInquilinos();
                 ViewBag.inquilinos = bdInqui.Getinquilinos();
                
                 
            return View("Renovar", contrato);
        }







         public ActionResult Rescindir(int Id)
        {
            
                 var monto = bdContratos.RescindirContrato(Id);
                 TempData["MontoRescindido"] =  monto.ToString();;
                 
            return RedirectToAction("Index");
        }
}
 }
