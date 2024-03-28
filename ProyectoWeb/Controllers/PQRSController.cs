using CapaDatos;
using CapaModelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoWeb.Controllers
{
    public class PQRSController : Controller
    {
        private static Usuario SesionUsuario;


        public ActionResult Index()
        {
            SesionUsuario = (Usuario)Session["Usuario"];

            return View();
        }

        public JsonResult Obtener()
        {
         
           List<PQRS> olista = CD_PQRS.Obtener();
            string data = "[";
            foreach (PQRS o in olista) {
                data += $@"[""{o.nombre}"",""{o.fecha_registro}"",""{o.tipo_pqrs}"",""{o.descripcion_afectacion}""]";
               
            
            }
            data += "]"; 
             
            
            
            

            return Json(new { data }, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult Guardar(PQRS objeto)
        {
            bool respuesta = false;

            if (objeto.id == 0)
            {


                respuesta = CD_PQRS.Registrar(objeto);
            }
            /*    else
                {
                    respuesta = CD_PQRS.Modificar(objeto);
                } */


            return Json(new { resultado = respuesta }, JsonRequestBehavior.AllowGet);
        }

    }
}