namespace InfoColeAplicacion.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<InfoColeAplicacion.Models.ApplicationDbContext>
    {
                public Configuration()
                {
                    AutomaticMigrationsEnabled = false;
                    ContextKey = "InfoColeAplicacion.Models.ApplicationDbContext";
                }

                protected override void Seed(InfoColeAplicacion.Models.ApplicationDbContext context)
                {
                    context.Noticias.AddOrUpdate(i => i.LinkNoticia,
                        new Models.Noticia
                        {
                            Titulo = "El Municipio empez� un proyecto sobre el transporte p�blico",
                            Descripcion = "La iniciativa propone un nuevo marco regulatorio para el servicio de la ciudad, y ya fue elevado al Consejo.",
                            LinkNoticia = "https://www.libertaddigital.com.ar/Notas/Nota/965116960-el-municipio-empezo-un-proyecto-sobre-el-transporte-publico",
                            LinkImagen = "https://radiolibertaddatastorage.blob.core.windows.net/radiolibertad-filecontainer/3rusqfitgnx.jpg",
                            FechaPublicacion= DateTime.Now
                        },

                         new Models.Noticia
                         {
                             Titulo = "Empresarios del transporte esperan los subsidios para poder pagar",
                             Descripcion = "Carlos Sartore, vicepresidente de la C�mara Empresaria del Transporte Automotor del Chaco (Cetach), se refiri� a...",
                             LinkNoticia = "https://www.libertaddigital.com.ar/Notas/Nota/1243286673-empresarios-del-transporte-esperan-los-subsidios-para-poder-pagar-salarios",
                             LinkImagen = "https://radiolibertaddatastorage.blob.core.windows.net/radiolibertad-filecontainer/aeb0blihdhl.jpg",
                             FechaPublicacion = DateTime.Now
                         },

                        new Models.Noticia
                        {
                            Titulo = "Transporte p�blico: se demora el pago a los choferes",
                            Descripcion = "Ra�l Abraham, secretario General de la UTA Chaco, habl� de la situaci�n salarial de los trabajadores",
                            LinkNoticia = "https://www.libertaddigital.com.ar/Notas/Nota/607547345-transporte-publico-se-demora-el-pago-a-los-choferes-y-se-enciende-la-amenaza-de-paro",
                            LinkImagen = "https://radiolibertaddatastorage.blob.core.windows.net/radiolibertad-filecontainer/t1witqemhh3.jpg",
                            FechaPublicacion = DateTime.Now
                        },

                         new Models.Noticia
                         {
                             Titulo = "Transporte p�blico en Resistencia: nuevas l�neas y recorridos",
                             Descripcion = "El secretario de Gobierno, Sebasti�n Lifton, dio detalles del plan que regir� a partir del 1 de julio de 2019.",
                             LinkNoticia = "https://www.libertaddigital.com.ar/Notas/Nota/773096246-transporte-publico-en-resistencia-nuevas-lineas-y-ampliacion-de-recorridos",
                             LinkImagen = "https://radiolibertaddatastorage.blob.core.windows.net/radiolibertad-filecontainer/qay0uwkwzhb.jpg",
                             FechaPublicacion = DateTime.Now
                         },
                        new Models.Noticia
                        {
                            Titulo = "Frenan el aumento de colectivo: 'La audiencia fue arbitraria e ilegal'",
                            Descripcion = "Esto denunci� el defensor del pueblo, Gustavo Corregido. Apunt� contra funcionarios provinciales y municipales.",
                            LinkNoticia = "https://www.libertaddigital.com.ar/Notas/Nota/664218496-frenan-el-aumento-de-colectivo-la-audiencia-fue-arbitraria-e-ilegal",
                            LinkImagen = "https://radiolibertaddatastorage.blob.core.windows.net/radiolibertad-filecontainer/p1vpefudvrx.jpg",
                            FechaPublicacion = DateTime.Now
                        },

                         new Models.Noticia
                         {
                             Titulo = "Quita total de subsidios al transporte: �Por ahora, son versiones�",
                             Descripcion = "Roberto Medina, subsecretario de Transporte provincial, a d�as de tratar un nuevo aumento del precio del boleto.",
                             LinkNoticia = "https://www.libertaddigital.com.ar/Notas/Nota/22502465-quita-total-de-subsidios-al-transporte-por-ahora-son-versiones",
                             LinkImagen = "https://radiolibertaddatastorage.blob.core.windows.net/radiolibertad-filecontainer/wczxslhcndr.jpg",
                             FechaPublicacion = DateTime.Now
                         },

                        new Models.Noticia
                        {
                            Titulo = "�El Chaco no puede pagar los subsidios al transporte�",
                            Descripcion = "Daniel Capitanich, vice gobernador del Chaco, fue contundente. 'Es imposible', dijo.",
                            LinkNoticia = "https://www.libertaddigital.com.ar/Notas/Nota/1427635561-el-chaco-no-puede-pagar-los-subsidios-al-transporte",
                            LinkImagen = "https://radiolibertaddatastorage.blob.core.windows.net/radiolibertad-filecontainer/oizbpryackg.jpg",
                            FechaPublicacion = DateTime.Now
                        },

                         new Models.Noticia
                         {
                             Titulo = "Sin acuerdo: siguen los paros nocturnos del transporte p�blico",
                             Descripcion = "Ra�l Abraham, secretario general de UTA Chaco, cont� que incluso la medida podr�a agravarse.",
                             LinkNoticia = "https://www.libertaddigital.com.ar/Notas/Nota/856179341-sin-acuerdo-siguen-los-paros-nocturnos-del-transporte-publico",
                             LinkImagen = "https://radiolibertaddatastorage.blob.core.windows.net/radiolibertad-filecontainer/2jzn2ljnzoo.jpg",
                             FechaPublicacion = DateTime.Now
                         },

                        new Models.Noticia
                        {
                            Titulo = "Audiencia p�blica: desde Transporte aguardan la decisi�n deJusticia",
                            Descripcion = "Roberto Medina, subsecretario de Transporte del Chaco, habl� de la presentaci�n que hizo el Defensor del Pueblo...",
                            LinkNoticia = "https://www.libertaddigital.com.ar/Notas/Nota/520215699-audiencia-publica-desde-transporte-aguardan-la-decision-de-la-justicia",
                            LinkImagen = "https://radiolibertaddatastorage.blob.core.windows.net/radiolibertad-filecontainer/dmydfo03h3e.jpg",
                            FechaPublicacion = DateTime.Now
                        }
           );
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
