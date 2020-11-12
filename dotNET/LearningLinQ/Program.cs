﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace LearningLinQ
{
    class Program
    {
        static void Main(string[] args)
        {
            // Sintaxis Query Expresion
            // Sintaxis fluida
            Console.WriteLine("Hello World!");

            int[] ArrayDeNumeros = { 1, 5, 7, 3, 5, 9, 8 };
            IEnumerable<int> ResultadoDelQuery =
                from x in ArrayDeNumeros
                where x < 3 && x < 8
                select x;

            foreach (var item in ResultadoDelQuery)
            {
                Console.WriteLine(item);
            }

            List<Estudiante> Estudiantes = new List<Estudiante>(){
                new Estudiante{ID = 1, Nombre = "Maria"},
                new Estudiante{ID = 2, Nombre = "Pedro"},
                new Estudiante{ID = 3, Nombre = "Jose"},
                new Estudiante{ID = 4, Nombre = "Juan"},
                new Estudiante{ID = 5, Nombre = "Carlos"}
            };

            IEnumerable<string> Query1 =
                from i in Estudiantes
                where i.ID <= 3
                select i.Nombre;

            foreach (string item in Query1)
            {
                Console.WriteLine(item);
            }
            Query1.ToList();
            Console.WriteLine(Query1.Count());

            IEnumerable<EstudianteDTO> resultado =
                from i in Estudiantes
                select new EstudianteDTO
                {
                    IDDTO = i.ID,
                    NombreDTO = i.Nombre
                };

            foreach (var x in resultado)
            {

                Console.WriteLine(x.ToString());
            }
            Console.WriteLine("__________");


            var resultado2 =
                from i in Estudiantes
                select new
                {
                    i.ID,
                    i.Nombre
                };

            foreach (var x in resultado2)
            {

                Console.WriteLine(x.ToString());
            }
            Console.WriteLine("__________");


            Console.WriteLine("**********************");

            List<int> listaA = new List<int> { 2, 4, 6, 8, 9 };
            List<int> listaB = new List<int> { 2, 5, 6, 7, 9 };

            // [Excep] Devuelve una secuencia que contiene la diferencia de conjuntos de los elementos de dos secuencias
            var expExcep = (from a in listaA select a)
                .Except(from b in listaB select b);

            Console.WriteLine("[Excep] Devuelve una secuencia que contiene la diferencia de conjuntos de los elementos de dos secuencias.");
            Console.WriteLine("[A].excep[B]: ");

            foreach (var item in expExcep)
            {
                Console.WriteLine(item);
            }

            var expExcep2 = (from a in listaB select a)
                .Except(from b in listaA select b);

            Console.WriteLine("[Excep] Devuelve una secuencia que contiene la diferencia de conjuntos de los elementos de dos secuencias.");
            Console.WriteLine("[B].excep[A]: ");

            foreach (var item in expExcep2)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("**********************");

            // [Intersect] Devuelve Una secuencia que contiene los elementos que forman la intersección(Elementos en comun) del conjunto de dos secuencias.
            var expInteersect = (from a in listaA select a)
                .Intersect(from b in listaB select b);

            Console.WriteLine("[Intersect] Devuelve Una secuencia que contiene los elementos que forman la intersección(Elementos en comun) del conjunto de dos secuencias.");
            Console.WriteLine("[A].Intersect[B]: ");

            foreach (var item in expInteersect)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("**********************");

            // [Unio] Produce la unión de conjuntos de dos secuencias mediante el comparador de igualdad (Tienen que ser iguales) 
            var expUnion = (from a in listaA select a)
                .Union(from b in listaB select b);

            Console.WriteLine("[Unio] Produce la unión de conjuntos de dos secuencias mediante el comparador de igualdad (Sin repeticiones)");
            Console.WriteLine("[A].Union[B]: ");

            foreach (var item in expUnion)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("**********************");


            // [Concat] Devuelve la concatenacion de 2 conjuntos (union de 2 elementos completo completa con repeteciones)
            var expConcat = (from a in listaA select a)
                .Concat(from b in listaB select b);

            Console.WriteLine("[Concat] Devuelve la concatenacion de 2 conjuntos (union de 2 elementos completo completa con repeteciones)");
            Console.WriteLine("[A].Concat[B]: ");

            foreach (var item in expConcat)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("**********************");

            // [Distinc] Compara los elementos de un conjunto y deuelve solo con los elementos que sea distintos(Elimina los duplicados)
            Console.WriteLine("[Distinc] Compara los elementos de 1 conjunto y deuelve solo con los elementos que sea distintos(Elimina los duplicados)");
            Console.WriteLine("expConcat.Distinct(): ");

            foreach (var item in expConcat.Distinct())
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("**********************");

            string[] ArrayPostres = { "Pie de Manzana", "Pie de Limon", "Chocolate con Manzana", "Mermelada de limon", "Mermelada de pina", "Mermelada de Manzana", "Pie de pera" };

            IEnumerable<string> PostresConManza =
                from i in ArrayPostres
                where i.Contains("Manzana")
                select i.ToLower();

            foreach (var item in PostresConManza)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("------------------------");
            // region aca 


            int[] numeros = { 1, 5, 4, 7, 6, 3, 5, 9, 8, 11 };
            // Take()
            //Devuelve un número especificado de elementos contiguos desde el inicio de una secuencia.
            IEnumerable<int> DesdeInicio = numeros.Take(5);
            Console.WriteLine("#####  Operadores LINQ  #####");
            Console.WriteLine("Devuelve un número especificado de elementos contiguos desde el inicio de una secuencia.");
            foreach (int item in DesdeInicio)
            {
                Console.WriteLine("numeros.take(5) {0}", item);
            }
            Console.WriteLine("___________");
            //Skip 
            //Omite un número específico de elementos en una secuencia y luego devuelve los elementos restantes.
            Console.WriteLine("Omite un número específico de elementos en una secuencia y luego devuelve los elementos restantes.");
            IEnumerable<int> Brinco = numeros.Skip(5);
            foreach (var item in Brinco)
            {
                Console.WriteLine("numeros.Skip(5): {0}", item);
            }
            Console.WriteLine("___________");
            Console.WriteLine("Reverse()");
            // Reverse()
            // Revesa la secencia
            foreach (var item in numeros)
            {
                Console.Write("[{0}],", item);
            }
            Console.Write("\n");

            IEnumerable<int> NumerosEnReversa = numeros.Reverse();
            foreach (var item in NumerosEnReversa)
            {
                Console.Write("[{0}],", item);
            }
            Console.WriteLine("__________");

            // retorna el Primer elemento
            //IEnumerable<int> PrimerElemento = numeros.First();
            int PrimerElemento = numeros.First();
            Console.WriteLine("[Primer Elemento]: {0}", PrimerElemento);

            // Ultimo elemento
            int UltimoElemento = numeros.Last();
            Console.WriteLine("[Ultimo Elemento]: {0}", UltimoElemento);

            // Encontrar un elemento en N posicion
            // Posicion 5 = El elemento es un 3
            int indexN = 5;
            int PosicionN = numeros.ElementAt(indexN);
            Console.WriteLine("[El elemento que busca es el]: {0}", PosicionN);
            // Retorna True o False si contiene X Elemento en la secuencia.
            bool ContieneX = numeros.Contains(99);
            Console.WriteLine("[Se encuentra el elemento?]: {0}", ContieneX);
            // Retorna True o False si encuentra algun elemento - False si no hay elementos
            bool TieneElementos = numeros.Any();
            Console.WriteLine("[La sencuencia tiene elementos?]: {0}", TieneElementos);
            bool TieneElementos2 = numeros.Any(x => x % 100 == 0);
            Console.WriteLine("[La sencuencia tiene un elementos divisible entre 100?]: {0}", TieneElementos2);

            IEnumerable<string> QueryPostres = ArrayPostres.OrderBy(x => x.Split().Last());
            
        }
    }
}