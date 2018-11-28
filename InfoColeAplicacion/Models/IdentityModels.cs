using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace InfoColeAplicacion.Models
{
    // Para agregar datos de perfil del usuario, agregue más propiedades a su clase ApplicationUser. Visite https://go.microsoft.com/fwlink/?LinkID=317594 para obtener más información.
    public class ApplicationUser : IdentityUser
    {
        public virtual ICollection<Comentario> Comentario { get; set; }

        [Display(Name = "Habilitado")]
        public bool Habilitado { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Tenga en cuenta que el valor de authenticationType debe coincidir con el definido en CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Agregar aquí notificaciones personalizadas de usuario
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<InfoColeAplicacion.Models.Comentario> Comentarios { get; set; }
        public System.Data.Entity.DbSet<InfoColeAplicacion.Models.Linea> Lineas { get; set; }
        public System.Data.Entity.DbSet<InfoColeAplicacion.Models.Ramal> Ramales { get; set; }
        public System.Data.Entity.DbSet<InfoColeAplicacion.Models.TipoPuntoMapa> TiposPuntoMapa { get; set; }
        public System.Data.Entity.DbSet<InfoColeAplicacion.Models.PuntoMapa> Puntos { get; set; }
        public System.Data.Entity.DbSet<InfoColeAplicacion.Models.Noticia> Noticias { get; set; }
        public System.Data.Entity.DbSet<InfoColeAplicacion.Models.Ruta> Rutas { get; set; }

        public System.Data.Entity.DbSet<InfoColeAplicacion.Models.Alerta> Alertas { get; set; }
        public System.Data.Entity.DbSet<InfoColeAplicacion.Models.Transito> Transitos { get; set; }
        public System.Data.Entity.DbSet<InfoColeAplicacion.Models.EstadoLinea> EstadoLineas { get; set; }
        public System.Data.Entity.DbSet<InfoColeAplicacion.Models.TipoAlerta> TipoAlertas { get; set; }
    }
}
