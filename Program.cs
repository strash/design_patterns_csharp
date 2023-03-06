using PatternManager;

namespace DesignPatterns
{
	internal class Programm
	{
		static void Main()
		{
			Console.ForegroundColor = ConsoleColor.Cyan;
			Console.WriteLine("\n> Creational patterns");

			Pattern simpleFactory = new SimpleFactoryPattern();
			simpleFactory.RunPattern();

			Pattern factoryMethod = new FactoryMethodPattern();
			factoryMethod.RunPattern();

			Pattern abstractFactory = new AbstractFactoryPattern();
			abstractFactory.RunPattern();

			Pattern builder = new BuilderPattern();
			builder.RunPattern();

			Pattern prototype = new PrototypePattern();
			prototype.RunPattern();

			Pattern singleton = new SingletonPattern();
			singleton.RunPattern();

			Console.ForegroundColor = ConsoleColor.Cyan;
			Console.WriteLine("\n> Structural patterns");

			Pattern adapter = new AdaptorPattern();
			adapter.RunPattern();

			Pattern bridge = new BridgePattern();
			bridge.RunPattern();

			Pattern composite = new CompositePattern();
			composite.RunPattern();

			Pattern decorator = new DecoratorPattern();
			decorator.RunPattern();

			Pattern facade = new FacadePattern();
			facade.RunPattern();

			Pattern flyweight = new FlyweightPattern();
			flyweight.RunPattern();

			Pattern proxy = new ProxyPattern();
			proxy.RunPattern();

			Console.ForegroundColor = ConsoleColor.Cyan;
			Console.WriteLine("\n> Behavioral patterns");

			Pattern chainOfResponsibility = new ChainOfResponsibilityPattern();
			chainOfResponsibility.RunPattern();

			Pattern command = new CommandPattern();
			command.RunPattern();

			Pattern iterator = new IteratorPattern();
			iterator.RunPattern();

			Pattern mediator = new MediatorPattern();
			mediator.RunPattern();

			Pattern memento = new MementoPattern();
			memento.RunPattern();

			Pattern observer = new ObserverPattern();
			observer.RunPattern();

			Pattern visitor = new VisitorPattern();
			visitor.RunPattern();

			Pattern strategy = new StrategyPattern();
			strategy.RunPattern();

			Pattern state = new StatePattern();
			state.RunPattern();

			Pattern template = new TemplatePattern();
			template.RunPattern();
		}
	}
}
