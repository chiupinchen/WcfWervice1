using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncFormTest
{
    public class BuildPattern 
    {
        public BuildPattern()
        {
            Director director = new Director(new Builder1());
            var product = director.Build();
        }

    }

    public class Director
    {
        private readonly Builder builder;

        public Director(Builder builder)
        { 
            this.builder = builder;
        }

        public Product Build()
        {
            this.builder.BuildPartA();
            this.builder.BuildPartB();
            return this.builder.GetProduct();
        }
    }

    public interface Builder
    {
        void BuildPartA();
        void BuildPartB();

        Product GetProduct();
       
    }

    public class Product
    {
        public string Content { get; set; }
    }

    public class Builder1 : Builder 
    {
        private Product product = new Product();
        public void BuildPartA()
        {
            product.Content = product.Content + "BuildPartA";
        }

        public void BuildPartB()
        {
            product.Content = product.Content + "BuildPartB";
        }


        public Product GetProduct()
        {
            return product;
        }
    }

    public class Builder2 : Builder
    {
        private Product product = new Product();
        public void BuildPartA()
        {
            product.Content = product.Content + "BuildPartX";
        }

        public void BuildPartB()
        {
            product.Content = product.Content + "BuildPartY";
        }


        public Product GetProduct()
        {
            return product;
        }
    }
}
