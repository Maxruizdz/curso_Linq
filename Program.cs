// See https://aka.ms/new-console-template for more information
using Curso_linq;

Console.WriteLine("Hello, World!");

LinqQueries queries = new LinqQueries();

//ImprimirLibros(queries.Libros());

//ImprimirLibros(queries.LibrosDespuesdel2000());

ImprimirLibros(queries.librosconmas_de250pag_TITULO_inAction());

void ImprimirLibros(IEnumerable<Book> listLibro) {


    Console.WriteLine("{0,-60} {1,10} {2,11}\n", "Titulo", "N. Paginas ", "Fecha Publicacion");

    foreach (var item in listLibro) {

        Console.WriteLine("{0,-60} {1,10} {2,11}", item.Title, item.PageCount, item.PublishedDate.ToShortDateString());


    } 




}

