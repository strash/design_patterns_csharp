using Adapter;
using Bridge;
using Builder;
using ChainOfResponsibility;
using Command;
using Composite;
using Decorator;
using Facade;
using Factory;
using Iterator;
using Mediator;
using Memento;
using Observer;
using Prototype;
using Proxy;
using Singleton;
using State;
using Strategy;
using Template;
using Visitor;

namespace PatternManager
{
	abstract class Pattern
	{
		public abstract void RunPattern();

		protected void _PrintPatternTitle(string title)
		{
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine($"\n- {title} -");
			Console.ForegroundColor = ConsoleColor.White;
		}

		protected int _ParseInt(string? input)
		{
			int res = 0;
			if (!int.TryParse(input, out res))
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine($"Error: \"{input}\" is not a fucking number");
				Console.ForegroundColor = ConsoleColor.White;
			}
			return res;
		}
	}

	class SimpleFactoryPattern : Pattern
	{
		public override void RunPattern()
		{
			this._PrintPatternTitle("Simple Factory");

			Console.WriteLine("Lets make a door.\nEnter the width:");
			int width = this._ParseInt(Console.ReadLine());
			Console.WriteLine("Enter the height:");
			int height = this._ParseInt(Console.ReadLine());

			Factory.IDoor door = DoorFactory.MakeDoor(width, height);
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine($"Heres your brand new door.\nDoor width is {door.GetWidth()} and height is {door.GetHeight()}");
		}
	}

	class FactoryMethodPattern : Pattern
	{
		public override void RunPattern()
		{
			this._PrintPatternTitle("Factory Method");

			Console.ForegroundColor = ConsoleColor.Green;
			HiringManager developmentManager = new DevelopmentManager();
			developmentManager.TakeInterview();

			HiringManager margetingManager = new MarketingManager();
			margetingManager.TakeInterview();
		}
	}

	class AbstractFactoryPattern : Pattern
	{
		public override void RunPattern()
		{
			this._PrintPatternTitle("Abstract Factory");

			Console.ForegroundColor = ConsoleColor.Green;
			IDoorFactory woodenDoorFactory = new WoodenDoorFactory();
			IDoorInfo woodenDoor = woodenDoorFactory.MakeDoor();
			IDoorFittingExpert carpenter = woodenDoorFactory.HireExpert();
			woodenDoor.Description();
			carpenter.Description();

			IDoorFactory ironDoorFactory = new WoodenDoorFactory();
			IDoorInfo ironDoor = ironDoorFactory.MakeDoor();
			IDoorFittingExpert welder = ironDoorFactory.HireExpert();
			ironDoor.Description();
			welder.Description();
		}
	}

	class BuilderPattern : Pattern
	{
		public override void RunPattern()
		{
			this._PrintPatternTitle("Builder");

			Console.WriteLine("Order a burger.\nEnter the size:");
			int size = this._ParseInt(Console.ReadLine());
			Console.ForegroundColor = ConsoleColor.Green;
			IBurger burger = new BurgerBuilder(size)
				.AddChese()
				.AddLettuce()
				.AddPepperoni()
				.Build();
			burger.ConfirmOrder();
		}
	}

	class PrototypePattern : Pattern
	{
		public override void RunPattern()
		{
			this._PrintPatternTitle("Prototype");

			Console.ForegroundColor = ConsoleColor.Green;
			Sheep original = new Sheep { Name = "Jolly", Category = "Mountain Sheep" };
			Console.WriteLine($"Original sheep. Name {original.Name}, category {original.Category}.");

			Sheep clone = original.ShallowCopy();
			clone.Name = "Dolly";
			clone.Category = "Clone";
			Console.WriteLine($"Shallow copy. Name {clone.Name}, category {clone.Category}.");

			Sheep copy = original.DeepCopy();
			Console.WriteLine($"Deep copy. Name {copy.Name}, category {copy.Category}.");
		}
	}

	class SingletonPattern : Pattern
	{
		public override void RunPattern()
		{
			this._PrintPatternTitle("Singleton");

			President president1 = President.GetInstance();
			President president2 = President.GetInstance();

			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine($"president1 == president2 - {Object.ReferenceEquals(president1, president2)}");
		}
	}

	class AdaptorPattern : Pattern
	{
		public override void RunPattern()
		{
			this._PrintPatternTitle("Adaptor");

			WildDog dog = new WildDog();
			ILion sudoDog = new WildDogAdaptor(dog);

			Console.ForegroundColor = ConsoleColor.Green;
			Hunter hunter = new Hunter();
			hunter.Hunt(sudoDog);
		}
	}

	class BridgePattern : Pattern
	{
		public override void RunPattern()
		{
			this._PrintPatternTitle("Bridge");

			ITheme darkTheme = new DarkTheme();
			ITheme lightTheme = new LightTheme();

			WebPage about = new AboutWebPage(darkTheme);
			WebPage careers = new CareersWebPage(darkTheme);

			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine(about.GetContent());
			Console.WriteLine(careers.GetContent());
		}
	}

	class CompositePattern : Pattern
	{
		public override void RunPattern()
		{
			this._PrintPatternTitle("Composite");

			var menu = new Menu("All", "McDonalds");

			var breakfast = new Menu("Breakfast", "Pancake House");
			var lunch = new Menu("Lunch", "Deli Diner");
			var dinner = new Menu("Dinner", "Dinneroni");

			var dessert = new Menu("Dessert", "Ice Cream");

			breakfast.Add(new MenuItem("Waffles", 140, "Butterscotch waffles"));
			breakfast.Add(new MenuItem("Corn Flakes", 80, "Kellogs"));

			lunch.Add(new MenuItem("Burger", 250, "Cheese and Onion Burger"));
			lunch.Add(new MenuItem("Sandwich", 280, "Chicken Sandwich"));

			dinner.Add(new MenuItem("Pizza", 210, "Cheese and Tomato Pizza"));
			dinner.Add(new MenuItem("Pasta", 280, "Chicken Pasta"));

			dessert.Add(new MenuItem("Ice Cream", 120, "Vanilla and Chocolate"));
			dessert.Add(new MenuItem("Cake", 180, "Choclate Cake Slice"));

			dinner.Add(dessert);

			menu.Add(breakfast);
			menu.Add(lunch);
			menu.Add(dinner);

			Console.ForegroundColor = ConsoleColor.Green;
			Composite.Client client = new(menu);
			client.ReadMenu();
		}
	}

	class DecoratorPattern : Pattern
	{
		public override void RunPattern()
		{
			this._PrintPatternTitle("Decorator");

			Console.ForegroundColor = ConsoleColor.Green;
			BaristaBuilder barista = new BaristaBuilder();
			barista.AddVanilla();
			barista.AddMilk();
			ICoffee coffee = barista.MakeCoffee();
			Console.WriteLine($"Heres your coffee {coffee.GetDescription()} : {coffee.GetCost()}");
		}
	}

	class FacadePattern : Pattern
	{
		public override void RunPattern()
		{
			this._PrintPatternTitle("Facade");

			ComputerFacade computer = new ComputerFacade(new Computer());

			Console.ForegroundColor = ConsoleColor.Green;
			computer.TurnOn();
			Console.WriteLine();
			computer.TurnOff();
		}
	}

	class FlyweightPattern : Pattern
	{
		public override void RunPattern()
		{
			this._PrintPatternTitle("Flyweight");

			Flyweight.Client coffeeShop = new();

			Console.ForegroundColor = ConsoleColor.Green;
			coffeeShop.TakeOrder("Cappuccino", 2);
			coffeeShop.TakeOrder("Frappe", 1);
			coffeeShop.TakeOrder("Espresso", 1);
			coffeeShop.TakeOrder("Frappe", 666);
			coffeeShop.TakeOrder("Cappuccino", 69);
			coffeeShop.TakeOrder("Frappe", 3);
			coffeeShop.TakeOrder("Espresso", 3);
			coffeeShop.TakeOrder("Cappuccino", 3);
			coffeeShop.TakeOrder("Espresso", 69);
			coffeeShop.TakeOrder("Espresso", 1);
			coffeeShop.TakeOrder("Espresso", 1);

			coffeeShop.Serve();
		}
	}

	class ProxyPattern : Pattern
	{
		public override void RunPattern()
		{
			this._PrintPatternTitle("Proxy");

			Console.ForegroundColor = ConsoleColor.Green;
			Proxy.IDoor door = new SecuredDoor(new Password("yaya"));
			door.Open();

			door = new SecuredDoor(new Password("secret_password"));
			door.Open();
			door.Close();
		}
	}

	class ChainOfResponsibilityPattern : Pattern
	{
		public override void RunPattern()
		{
			this._PrintPatternTitle("Chain of Responsibility");

			Account bank = new Bank(100);
			Account paypal = new Paypal(200);
			Account bitcoin = new Bitcoin(300);

			bank.SetNext(paypal);
			paypal.SetNext(bitcoin);

			Console.ForegroundColor = ConsoleColor.Green;
			bank.Pay(259);
		}
	}

	class CommandPattern : Pattern
	{
		public override void RunPattern()
		{
			this._PrintPatternTitle("Command");

			Light lightReceiver = new();

			ICommand turnOnCommand = new TurnOn(lightReceiver);
			ICommand turnOffCommand = new TurnOff(lightReceiver);

			RemoteControl invoker = new();

			Console.ForegroundColor = ConsoleColor.Green;
			invoker.DoTheThing(turnOnCommand);
			invoker.DoTheThing(turnOffCommand);
			invoker.UndoThatLastThing();
			invoker.UndoThatLastThing();
		}
	}

	class IteratorPattern : Pattern
	{
		public override void RunPattern()
		{
			this._PrintPatternTitle("Iterator");

			RadioStation[] stations = new RadioStation[4] {
				new (105.3f),
				new (302f),
				new (420.69f),
				new (10.01f)
			};

			Console.ForegroundColor = ConsoleColor.Green;
			Stations stationList = new(stations);
			foreach (RadioStation station in stationList)
				Console.WriteLine(station.Frequency);
		}
	}

	class MediatorPattern : Pattern
	{
		public override void RunPattern()
		{
			this._PrintPatternTitle("Mediator");

			ManagerMediator manager = new();

			CustomerColleague customer = new(manager);
			ProgrammerColleague programmer = new(manager);
			TesterColleague tester = new(manager);

			manager.Customer = customer;
			manager.Programmer = programmer;
			manager.Tester = tester;

			Console.ForegroundColor = ConsoleColor.Green;
			customer.Send("We have an order, need to make a programm");
			programmer.Send("I have done program, need to test it");
			tester.Send("I have done testing, here is ready program for you");
		}
	}

	class MementoPattern : Pattern
	{
		public override void RunPattern()
		{
			this._PrintPatternTitle("Memento");

			Originator editor = new();

			editor.Edit("This is the first sentence");
			editor.Edit("This is second");

			Memento.Memento memento = editor.Save();

			editor.Edit("And this is third");
			editor.Restore(memento);

			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine(editor.GetContent());
		}
	}

	class ObserverPattern : Pattern
	{
		public override void RunPattern()
		{
			this._PrintPatternTitle("Observer");

			Agency subject = new();

			Observer.Observer johnDoe = new("John Doe");
			Observer.Observer janeDoe = new("Jane Doe");

			IDisposable unsub1 = subject.Subscribe(johnDoe);
			IDisposable unsub2 = subject.Subscribe(janeDoe);

			Console.ForegroundColor = ConsoleColor.Green;
			subject.Emit("Software Developer");

			unsub2.Dispose();

			subject.Emit("UI Designer");
		}
	}

	class VisitorPattern : Pattern
	{
		public override void RunPattern()
		{
			this._PrintPatternTitle("Visitor");

			Monkey monkey = new();
			Lion lion = new();
			Dolphin dolphin = new();

			Speak speakVisitor = new();

			Console.ForegroundColor = ConsoleColor.Green;
			monkey.Accept(speakVisitor);
			lion.Accept(speakVisitor);
			dolphin.Accept(speakVisitor);
		}
	}

	class StrategyPattern : Pattern
	{
		public override void RunPattern()
		{
			this._PrintPatternTitle("Strategy");

			Console.ForegroundColor = ConsoleColor.Green;

			int[] dataSet = new int[6] { 1, 5, 4, 3, 2, 8 };
			Sorter sorter = new();
			sorter.Sort<int>(dataSet, new BubbleSortStrategy());
			sorter.Sort<int>(dataSet, new QuickSortStrategy());
		}
	}

	class StatePattern : Pattern
	{
		public override void RunPattern()
		{
			this._PrintPatternTitle("State");

			Phone phone = new();

			Console.ForegroundColor = ConsoleColor.Green;
			phone.PickUp();
			phone.HangUp();
			phone.PickUp();
			phone.Dial();
			phone.HangUp();
		}
	}

	class TemplatePattern : Pattern
	{
		public override void RunPattern()
		{
			this._PrintPatternTitle("Template");

			Console.ForegroundColor = ConsoleColor.Green;
			BuildTemplate androidBuilder = new AndroidBuildTemplate();
			androidBuilder.Build();

			BuildTemplate iosBuilder = new IosBuildTemplate();
			iosBuilder.Build();
		}
	}
}
