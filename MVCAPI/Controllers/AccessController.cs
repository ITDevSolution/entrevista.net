using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MVCAPI.Models.WS;
using MVCAPI.Models;

namespace MVCAPI.Controllers
{
    public class AccessController : ApiController
    {
        [HttpGet]
        public Reply HelloWorld()
        {
            Reply or = new Reply();
            or.result = 1;
            or.message = "Hello World";

            return or;
        }

        [HttpPost]
        public Reply AddContacto(ContactoViewModel model)
        {
            Reply or = new Reply();
            or.result = 0;
            try
            {
                using (dbempresasEntities db = new dbempresasEntities())
                {
                    contacto contacto = new contacto();
                    contacto.nombre = model.nombre;
                    contacto.celular = model.celular;
                    contacto.direccion = model.direccion;
                    contacto.correo = model.correo;
                    contacto.idempresa = model.Idempresa;

                    db.contacto.Add(contacto);
                    db.SaveChanges();

                    or.result = 1;
                    or.data = "200 ok";
                    or.message = "exito";
                }

            }catch(Exception ex)
            {
                or.message = "Ocurrio un error en el servidor";
            }
            return or;
        }

        [HttpPut]
        public Reply EditContacto(ContactoViewModel model)
        {
            Reply or = new Reply();
            or.result = 0;
            try
            {
                using (dbempresasEntities db = new dbempresasEntities())
                {
                    contacto contacto = db.contacto.Find(model.Id);
                    contacto.nombre = model.nombre;
                    contacto.celular = model.celular;
                    contacto.direccion = model.direccion;
                    contacto.correo = model.correo;
                    contacto.idempresa = model.Idempresa;

                    db.Entry(contacto).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();

                    or.result = 1;
                    or.data = "200 ok";
                    or.message = "edit ok";
                }

            }
            catch (Exception ex)
            {
                or.message = "Ocurrio un error en el servidor";
            }
            return or;
        }

        [HttpDelete]
        public Reply DeleteContacto(ContactoViewModel model)
        {
            Reply or = new Reply();
            or.result = 0;
            try
            {
                using (dbempresasEntities db = new dbempresasEntities())
                {

                    contacto contacto = db.contacto.Find(model.Id);
                    if(contacto == null)
                    {
                        or.message = "not found contacto";
                    }


                    db.Entry(contacto).State = System.Data.Entity.EntityState.Deleted;
                    db.SaveChanges();

                    or.result = 1;
                    or.data = "200 ok";
                    or.message = "delete ok";
                }

            }
            catch (Exception ex)
            {
                or.message = "Ocurrio un error en el servidor";
            }
            return or;
        }

        /*[HttpPost]
        public Reply Login( AccessViewModel model)
        {
            Reply or = new Reply();
            or.result = 0;
            try
            {
                using (DBVentasEntities db = new DBVentasEntities())
                {
                    var lst = db.User.Where(d => d.email == model.email && d.password == model.password && d.estado == 1);
                    
                    if(lst.Count() > 0)
                    {
                        or.result = 1;
                        or.data = Guid.NewGuid().ToString();

                        User user = lst.First();
                        user.token = or.data.ToString();
                        db.Entry(user).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();

                    }else
                    {
                        or.message = "Datos incorrectos o no tiene acceso";
                    }
                }
            }
            catch(Exception ex)
            {
                or.result = 0;
                or.message = "No access";
            }
            return or;
        }
        */

    }
}
