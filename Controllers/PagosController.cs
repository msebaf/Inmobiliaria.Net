using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Inmobiliaria.Net.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace Inmobiliaria.Net.Controllers
{
    [Authorize]
    public class PagosController : Controller
    {
        public readonly BdPagos bdPagos = new BdPagos();
        // GET: Inmuebles
        public ActionResult Index(int? id)
        {   
            if(id!= null){
            var pagos = bdPagos.GetPagos(id);
            ViewBag.id = id;
            return View(pagos);

        }else{
               var pagos = bdPagos.GetPagos(null);
            return View(pagos);
        }
        }

    

        // GET: Inmuebles/Create
        public ActionResult Create()
        {
            BdContratos bdcCnts = new BdContratos();
            
           
                 ViewBag.contratos = bdcCnts.GetContratos(null);
             
                 
            return View();
        }

        // POST: Inmuebles/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Pago pago)
        {
            int? idCont= pago.ContratoId;
            try
            {
                // TODO: Add insert logic here
                int res = bdPagos.Alta(pago);
                
                return RedirectToAction("Index", new { id = idCont });
            }
            catch
            {
                 
                return View();
            }
        }

        // GET: Inmuebles/Edit/5
        public ActionResult Edit(int id)
        {
            BdContratos bdcCnts = new BdContratos();
            
           
                 ViewBag.contratos = bdcCnts.GetContratos(null);
            var contrato = bdPagos.GetPago(id);
           
            
            return View(contrato);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Pago pago)
        {
            try
            {
                // TODO: Add update logic here
                
                bdPagos.Actualizar(pago);
                return RedirectToAction("Index", new { id = pago.ContratoId });
                
            }
            catch
            {
           
                return View();
            }
        }

       

        // GET: Inmuebles/Delete/5
        [Authorize(Policy = "Administrador")]
        public ActionResult Delete(int id)
        {
           
           Pago pago =  bdPagos.GetPago(id);
            return View(pago);
        }

        // POST: Inmuebles/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "Administrador")]
        public ActionResult Delete(int id, Pago pago)
        {
            try
            {
                // TODO: Add delete logic here
                bdPagos.DeletePago(id);

                 return RedirectToAction("Index", new { id = pago.ContratoId });
            }
            catch
            {
                return View();
            }
        }
        

          public ActionResult PagarInm(int id)
        {
            BdContratos bdcCnts = new BdContratos();
            
           
                Contrato contrato = bdcCnts.GetContrato(id);
              ViewBag.mMensual = contrato.MontoMensual;
              ViewBag.cId = id;
                 
            return View();
        }


        public ActionResult Details(int id)
        {
            var pago = bdPagos.GetPago(id);
            return View(pago);
        }

      

    }
}

