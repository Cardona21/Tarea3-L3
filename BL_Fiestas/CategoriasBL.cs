﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL_Fiestas
{
    public class CategoriasBL
    {
        Contexto _contexto;
        public BindingList<Categoria> ListaCategoria { get; set; }

        public CategoriasBL()
        {
            _contexto = new Contexto();
            ListaCategoria = new BindingList<Categoria>();
        }

        public BindingList<Categoria> ObtenerCategorias()
        {
            _contexto.Categorias.Load();
            ListaCategoria = _contexto.Categorias.Local.ToBindingList();

            return ListaCategoria;
        }


    }
    public class Categoria
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
    }
}