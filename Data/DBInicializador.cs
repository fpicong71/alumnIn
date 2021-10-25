using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebFormacion.Models;


namespace WebFormacion.Data
{
    public class DBInicializador
    {
        public static void Initialize(WebContext context)
        {
            context.Database.EnsureCreated();

            //Relleno Entidades
            if (context.EntidadFormacion.Any())
            {
                return;
            }
            var entidades = new Entidad[] {
                new Entidad{EntidadID="12345678K",RazonSocial="Nowe",Direccion="C/ Melilla, 5",CodigoPostal=28005},
                new Entidad{EntidadID="84576211R",RazonSocial="Cei",Direccion="C/ Rodriguez San Pedro, 2",CodigoPostal=28015},
                new Entidad{EntidadID="66778899G",RazonSocial="Impulso 06",Direccion="C/ Embajadores, 78",CodigoPostal=28012},
                new Entidad{EntidadID="89775143D",RazonSocial="Academia Colón",Direccion="C/ Gral.Palanca, 26",CodigoPostal=28045},
                new Entidad{EntidadID="23577810L",RazonSocial="Adams Formación",Direccion="C/ Ayala, 130",CodigoPostal=28006}
            };
            foreach (Entidad en in entidades)
            {
                context.EntidadFormacion.Add(en);
            }
            context.SaveChanges();

            //Relleno Contactos
            if (context.Contacto.Any())
            {
                return;
            }
            var contactos = new Contacto[] {
                new Contacto{ContactoID="32457788R",Nombre="José",Apellido1="Gómez",Apellido2="García",Puesto="Comercial"},
                new Contacto{ContactoID="03457821G",Nombre="María",Apellido1="Rodriguez",Apellido2="Gallardo",Puesto="Administrativo"},
                new Contacto{ContactoID="88756921S",Nombre="Raquel",Apellido1="García",Apellido2="Peinado",Puesto="Administrativo"},
                new Contacto{ContactoID="12365498S",Nombre="Manuel",Apellido1="Gálvez",Apellido2="Tijeras",Puesto="Comercial"},
                new Contacto{ContactoID="54123677U",Nombre="Mónica",Apellido1="Sanchez",Apellido2="Sanchez",Puesto="Comercial"},
                new Contacto{ContactoID="99999999F",Nombre="Samuel",Apellido1="Manrique",Apellido2="Rojo",Puesto="Administrativo"},
                new Contacto{ContactoID="88554411U",Nombre="Blanca",Apellido1="Tejerina",Apellido2="Sanchez",Puesto="Comercial"}
            };
            foreach (Contacto c in contactos)
            {
                context.Contacto.Add(c);
            }
            context.SaveChanges();

            //Relleno Curso
            if (context.Curso.Any())
            {
                return;
            }
            var cursos = new Curso[] {
                new Curso{CursoID="012DIS",NombreCurso="Diseño Gráfico Publicitario",DescripcionCurso="Desarrolla tu actividad profesional en departamentos de diseño gráfico."},
                new Curso{CursoID="021FDIG",NombreCurso="Fotografía Digital",DescripcionCurso="Aprender a manejar las herramientas de Adobe Photoshop y familiarizarte con los conceptos básicos de imagen y fotografía digital, color, composición y retoque fotográfico."},
                new Curso{CursoID="023INDES",NombreCurso="Adobe Indesign",DescripcionCurso="Curso monográfico de maquetación editorial con Indesign"},
                new Curso{CursoID="00115MMDC",NombreCurso="Master en Marketing Digital y de Contenidos",DescripcionCurso="En el Máster de Marketing Digital y de Contenidos los alumnos aprenderán las técnicas más importantes del marketing digital y, además, aprenderán a crear y gestionar cualquier tipo de contenido en una página web a través de WordPress."},
                new Curso{CursoID="SSCE0109",NombreCurso="Información Juvenil",DescripcionCurso="En este certificado oficial, aprenderás a trabajar organizando y gestionando servicios de información para jóvenes desarrollando acciones de información, orientación, dinamización de la información, promoviendo actividades socioeducativas en el marco de la educación no formal orientadas a hacer efectiva la igualdad de oportunidades y el desarrollo integral de los jóvenes."},
                new Curso{CursoID="ARGN0110",NombreCurso="Desarrollo de Productos Editoriales Multimedia",DescripcionCurso="Desarrollar productos multimedia a partir de proyectos editoriales; realizar el diseño de los elementos gráficos y multimedia necesarios para obtener el producto, gestionando y controlando la calidad del producto editorial multimedia."},
                new Curso{CursoID="MF1051_2",NombreCurso="Inglés Profesional para Servicios de Reatauración",DescripcionCurso="Inglés para restauración."}
            };
            foreach (Curso c in cursos)
            {
                context.Curso.Add(c);
            }
            context.SaveChanges();

            //Relleno Alumnos
            if (context.Alumno.Any())
            {
                return;
            }
            var alumnos = new Alumno[] {
                new Alumno{AlumnoID="jorgegy@yahoo.es",Nombre="Jorge",Apellido1="Martinez", Apellido2="Fonseca",Telefono="636332578",Direccion="C/ del Alamillo, 5",CodigoPostal=28006},
                new Alumno{AlumnoID="noeliaglu@yahoo.es",Nombre="Noelia",Apellido1="Nogueira", Apellido2="Álvarez",Telefono="914778952",Direccion="C/ Montserrat, 15",CodigoPostal=28040},
                new Alumno{AlumnoID="manuelma@gmail.com",Nombre="Manuel",Apellido1="Martinez", Apellido2="Mulero",Telefono="625634845",Direccion="C/ Sierra Alta, 20",CodigoPostal=28013},
                new Alumno{AlumnoID="beacordoba@gmail.com",Nombre="Beatriz",Apellido1="Cordoba", Apellido2="Espósito",Telefono="950235674",Direccion="C/ Lope de Vega, 20",CodigoPostal=28003},
                new Alumno{AlumnoID="margaritar@telefonica.com",Nombre="Margarita",Apellido1="Rodriguez", Apellido2="Salas",Telefono="611457930",Direccion="C/ Beata, 45",CodigoPostal=28001}
            };
            foreach (Alumno a in alumnos)
            {
                context.Alumno.Add(a);
            }
            context.SaveChanges();

            //Relleno Historial
            if (context.Historial.Any())
            {
                return;
            }
            var historiales = new Historial[] {
                new Historial{AlumnoID="jorgegy@yahoo.es",ContactoID="54123677U", CursoID="012DIS",Fecha=DateTime.Parse("2021-03-02"),Medio="Teléfono",Mensaje="El curso comienza el próximo mes"},
                new Historial{AlumnoID="jorgegy@yahoo.es",ContactoID="54123677U", CursoID="012DIS",Fecha=DateTime.Parse("2021-03-03"),Medio="Correo",Mensaje="El curso cuesta 2500€"},
                new Historial{AlumnoID="jorgegy@yahoo.es",ContactoID="54123677U", CursoID="012DIS",Fecha=DateTime.Parse("2021-03-15"),Medio="Correo",Mensaje="Debes abonar la matrícula para reservar la plaza"},
                new Historial{AlumnoID="beacordoba@gmail.com",ContactoID="12365498S", CursoID="MF1051_2",Fecha=DateTime.Parse("2021-02-14"),Medio="Correo",Mensaje="Petición de información"},
                new Historial{AlumnoID="noeliaglu@yahoo.es",ContactoID="32457788R", CursoID="SSCE0109",Fecha=DateTime.Parse("2021-02-28"),Medio="Correo",Mensaje="Petición de información"},
                new Historial{AlumnoID="noeliaglu@yahoo.es",ContactoID="32457788R", CursoID="SSCE0109",Fecha=DateTime.Parse("2021-03-03"),Medio="Correo",Mensaje="Requisitos Inscripción"}
            };
            foreach (Historial h in historiales)
            {
                context.Historial.Add(h);
            }
            context.SaveChanges();

            //Relleno EntidadContactos
            if (context.EntidadContacto.Any())
            {
                return;
            }
            var entcontactos = new EntidadContacto[] {
               new EntidadContacto {EntidadID="12345678K", ContactoID="54123677U"},
               new EntidadContacto {EntidadID="23577810L", ContactoID="12365498S"},
               new EntidadContacto {EntidadID="89775143D", ContactoID="32457788R"},
               new EntidadContacto {EntidadID="84576211R", ContactoID="03457821G"},
               new EntidadContacto {EntidadID="66778899G", ContactoID="88756921S"},
               new EntidadContacto {EntidadID="12345678K", ContactoID="99999999F"},
               new EntidadContacto {EntidadID="23577810L", ContactoID="88554411U"}
              
            };
            foreach (EntidadContacto ec in entcontactos)
            {
                context.EntidadContacto.Add(ec);
            }
            context.SaveChanges();

            //Relleno CursoEntidad
            if (context.CursoEntidad.Any())
            {
                return;
            }
            var cursosentidades = new CursoEntidad[] {
               new CursoEntidad {EntidadID="12345678K", CursoID="012DIS"},
               new CursoEntidad {EntidadID="12345678K", CursoID="021FDIG"},
               new CursoEntidad {EntidadID="12345678K", CursoID="023INDES"},
               new CursoEntidad {EntidadID="84576211R", CursoID="00115MMDC"},
               new CursoEntidad {EntidadID="66778899G", CursoID="ARGN0110"},
               new CursoEntidad {EntidadID="23577810L", CursoID="MF1051_2"},
               new CursoEntidad {EntidadID="89775143D", CursoID="SSCE0109"}  

            };
            foreach (CursoEntidad ce in cursosentidades)
            {
                context.CursoEntidad.Add(ce);
            }
            context.SaveChanges();

        }

    }
}
