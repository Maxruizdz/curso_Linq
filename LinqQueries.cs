using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso_linq
{
    internal class LinqQueries
    {

        private List<Book> librosCollection = new List<Book>();
        private const string filePath = "books.json";
        public LinqQueries()
        {

            using (StreamReader reader = new StreamReader(filePath))
            {


                string Json = reader.ReadToEnd();

                this.librosCollection = System.Text.Json.JsonSerializer.Deserialize<List<Book>>(Json, new System.Text.Json.JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            }


        }

        public IEnumerable<Book> Libros()
        {


            return librosCollection;

        }
        public IEnumerable<Book> LibrosDespuesdel2000()
        {

            //extension method

            //return librosCollection.Where(p => p.PublishedDate.Year > 2000);

            //Query expresion

            return from l in librosCollection
                   where l.PublishedDate.Year > 2002
                   select l;
        }


        public IEnumerable<Book> librosconmas_de250pag_TITULO_inAction()
        {

            //Extension method
            //return librosCollection.Where(p => p.PageCount > 250 && p.Title.Contains("in Action"));

            //Query expresion

            return from l in librosCollection
                   where l.PageCount > 250 && l.Title.Contains("in Action")
                   select l;

        }
        public bool elements_conValor_campoStatus()
        {
            //expresion method
            return librosCollection.All(p => p.status != null || p.status != String.Empty);



        }

        public bool libros_public_en2005()
        {


            return librosCollection.Any(p => p.PublishedDate.Year == 2005);

        }

        public IEnumerable<Book> LibrodePython()
        {
            //extensions method

            return librosCollection.Where(p => p.Categories.Contains("Python"));



        }

        public IEnumerable<Book> LibrodeJava()
        {

            return librosCollection.Where(p => p.Categories.Contains("Java")).OrderBy(p => p.Title);

        }
        public IEnumerable<Book> Libros_conmasde_450paginas() {
            //extensions method

            // return librosCollection.Where(p => p.PageCount > 450).OrderByDescending(p => p.PageCount);

            //Query expresion


            return from libro in librosCollection
                   where libro.PageCount > 450
                   orderby libro.PageCount descending
                   select libro;


        }
        public IEnumerable<Book> ultimos_libros_java() {


            return librosCollection.Where(p => p.Categories.Contains("Java")).Take(3).OrderByDescending(p => p.PublishedDate);

        }


        public IEnumerable<Book> TerceryCuartoLibroDeMas400Pag() {



            return librosCollection.Where(p => p.PageCount > 400).Take(4).Skip(2);

        }
        public IEnumerable<Book> primeros3libros_() {

            return librosCollection.Take(3).Select(p => new Book { Title = p.Title, PageCount = p.PageCount });



        }

        public int cant_libre_entre200y500pag() {

            //extension method

            return librosCollection.Count(p => p.PageCount >= 200 && p.PageCount <= 500);



        }
        public long cant_libre_entre200y500()
        {

            //extension method

            return librosCollection.LongCount(p => p.PageCount >= 200 && p.PageCount <= 500);



        }
        public DateTime menor_fechaPublicacion() {

            return librosCollection.Min(p => p.PublishedDate);



        }
        public int libro_conmaspaginas() {


            return librosCollection.Max(p => p.PageCount);

        }
        public Book LibroconmenorNumero_Pagina() {



            return librosCollection.Where(p => p.PageCount > 0).MinBy(p => p.PageCount);


        }
        public Book Libroconfecha_masreciente() {


            return librosCollection.MaxBy(p => p.PublishedDate);

        }
        public int cantidad_Depaginas_deTodosLosLibro() {


            return librosCollection.Where(p => p.PageCount >= 0 && p.PageCount <= 500).Sum(p => p.PageCount);

        }
        public string TitulosDelLibroDespuesdel2015Concatenados() {

            return librosCollection
                    .Where(p => p.PublishedDate.Year > 2015)
                    .Aggregate("", (TitulosLibros, next) =>
                    {
                        if (TitulosLibros != string.Empty)
                            TitulosLibros += " - " + next.Title;
                        else
                            TitulosLibros += next.Title;

                        return TitulosLibros;
                    });




        }
        public double Promedio_caracteres_Titulos() {

            return librosCollection.Where(p=>p.Title.Length> 0).Average(p=> p.Title.Length);
        
        
        }



    }
}
