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
        public LinqQueries() {

            using (StreamReader reader = new StreamReader(filePath)) {


                string Json = reader.ReadToEnd();

                this.librosCollection = System.Text.Json.JsonSerializer.Deserialize<List<Book>>(Json, new System.Text.Json.JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            }


        }

        public IEnumerable<Book> Libros() {


            return librosCollection;

        }
        public IEnumerable<Book> LibrosDespuesdel2000() {

            //extension method

            //return librosCollection.Where(p => p.PublishedDate.Year > 2000);

            //Query expresion

            return from l in librosCollection
                   where l.PublishedDate.Year > 2002
                   select l;
        }


        public IEnumerable<Book> librosconmas_de250pag_TITULO_inAction() {

            //Extension method
            //return librosCollection.Where(p => p.PageCount > 250 && p.Title.Contains("in Action"));

            //Query expresion

            return from l in librosCollection
                   where l.PageCount > 250 && l.Title.Contains("in Action")
                   select l;
        
        }
    }
}
