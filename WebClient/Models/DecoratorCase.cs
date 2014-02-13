using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebClient.Models
{
    public class DecoratorCase
    {
    }
}

/// <summary>

/// MainApp startup class for Structural

/// Decorator Design Pattern.

/// </summary>

class MainApp
{

    /// <summary>

    /// Entry point into console application.

    /// </summary>

    static void Main()
    {

        // Create ConcreteComponent and two Decorators

        

        

       


        // Wait for user

        Console.ReadKey();

    }

}



/// <summary>

/// The 'Component' abstract class

/// </summary>

abstract class Component
{

    public abstract void Operation();

}



/// <summary>

/// The 'ConcreteComponent' class

/// </summary>

class ConcreteComponent : Component
{

    public override void Operation()
    {

        Console.WriteLine("ConcreteComponent.Operation()");

    }

}



/// <summary>

/// The 'Decorator' abstract class

/// </summary>

abstract class Decorator : Component
{

    protected Component component;



    public void SetComponent(Component component)
    {

        this.component = component;

    }



    public override void Operation()
    {

        if (component != null)
        {

            component.Operation();

        }

    }

}



/// <summary>

/// The 'ConcreteDecoratorA' class

/// </summary>

class ConcreteDecoratorA : Decorator
{

    public ConcreteDecoratorA(Component component)
    {
        base.component = component;
    }

    public override void Operation()
    {
        component.Operation();

        
        Console.WriteLine("ConcreteDecoratorA.Operation()");

    }

}



/// <summary>

/// The 'ConcreteDecoratorB' class

/// </summary>

class ConcreteDecoratorB : Decorator
{
   
    public ConcreteDecoratorB(Component component)
    {
        base.component = component;
    }

    public override void Operation()
    {

        component.Operation();

        AddedBehavior();

        Console.WriteLine("ConcreteDecoratorB.Operation()");

    }



    void AddedBehavior()
    {

    }

}

