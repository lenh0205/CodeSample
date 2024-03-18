namespace ConsoleApp1.Example
{
    public interface IValidate
    {
        bool IsOk(string text);
    }
    public class TextNotEmpty : IValidate
    {
        public bool IsOk(string text)
        {
            return !string.IsNullOrEmpty(text);
        }
    }
    public class TextAtLeast8Chars : IValidate
    {
        public bool IsOk(string text)
        {
            return text.Length >= 8;
        }
    }

    [Custom]
    public class ReflectionInformation
    {
        [Custom]
        private int _id;
        private string _name;

        [Custom]
        public ReflectionInformation()
        {
        }
        public ReflectionInformation(int id)
        {
            Id = id;
        }
        public ReflectionInformation(int id, string name)
        {
            Id = id;
            Name = name;
        }

        [Custom]
        public int Id { get; set; }
        public string Name { get; set; }

        [Custom]
        public void Write()
        {
            Console.WriteLine("Id: " + Id);
            Console.WriteLine("Name: " + Name);
        }
        public void Write(string name)
        {
            Console.WriteLine("Name: " + name);
        }
    }


    public class ReflectionCSharp
    {
        //public void Run1()
        //{
        //    var fullName = string.Empty;
        //    var assemblyName = string.Empty;
        //    var constructors = new List<string>();

        //    var type = typeof(int);
        //    fullName = type.FullName;
        //    assemblyName = type.Assembly.FullName;
        //    var listConstructors = type.GetConstructors().ToList();
        //    foreach (var item in listConstructors) constructors.Add(item.Name);

        //    Console.WriteLine("Type.FullName: " + fullName);
        //    Console.WriteLine("Type.Assembly.FullName: " + assemblyName);
        //    Console.WriteLine("Type.GetConstructors: " + string.Join(", ", constructors));
        //    Console.WriteLine("==============================");

        //    double i = 100d;
        //    type = i.GetType();
        //    fullName = type.FullName;
        //    assemblyName = type.Assembly.FullName;
        //    constructors.Clear();
        //    listConstructors = type.GetConstructors().ToList();
        //    foreach (var item in listConstructors) constructors.Add(item.Name);

        //    Console.WriteLine("Type.FullName: " + fullName);
        //    Console.WriteLine("Type.Assembly.FullName: " + assemblyName);
        //    Console.WriteLine("Type.GetConstructors: " + string.Join(", ", constructors));
        //    Console.WriteLine("==============================");

        //    var reflectionInfo = new ReflectionInformation("Name", "Value");
        //    type = reflectionInfo.GetType();
        //    fullName = type.FullName;
        //    assemblyName = type.Assembly.FullName;
        //    constructors.Clear();
        //    listConstructors = type.GetConstructors().ToList();
        //    foreach (var item in listConstructors) constructors.Add(item.ToString());

        //    Console.WriteLine("Type.FullName: " + fullName);
        //    Console.WriteLine("Type.Assembly.FullName: " + assemblyName);
        //    Console.WriteLine("Type.GetConstructors: " + string.Join(", ", constructors));
        //}


        public void Run2()
        {
            var reflectionInfo = new ReflectionInformation();
            var type = reflectionInfo.GetType();

            var attrs = type.Attributes;
            Console.WriteLine("Class.Attribute: " + attrs); // list of .NET default attribute 

            var customAttrs = type.CustomAttributes;
            Console.WriteLine("Class.Custom.Attribute: " + customAttrs); // list of attribute defined by user


            var constructors = type.GetConstructors();
            foreach (var item in constructors) Console.WriteLine(item);

            var methods = type.GetMethods();
            foreach (var item in methods) Console.WriteLine(item);
        }


        public void Run()
        {
            var type = typeof(IValidate);

            var needValids = AppDomain.CurrentDomain
                .GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p) && !p.IsInterface && !p.IsAbstract);

            foreach (var item in needValids) Console.WriteLine(item);
            Console.WriteLine("==================");


            var text = string.Empty;
            foreach (var item in needValids)
            {
                var o = Activator.CreateInstance(item, null) as IValidate;
                var ok = o.IsOk(text);

                Console.WriteLine(item + "==" + text + "==" + ok);
            }
            Console.WriteLine("==================");

            text = "WTF";
            foreach (var item in needValids)
            {
                var o = Activator.CreateInstance(item, null) as IValidate;
                var ok = o.IsOk(text);

                Console.WriteLine(item + "==" + text + "==" + ok);
            }
            Console.WriteLine("==================");

            text = "WTF WTF WTF";
            foreach (var item in needValids)
            {
                var o = Activator.CreateInstance(item, null) as IValidate;
                var ok = o.IsOk(text);

                Console.WriteLine(item + "==" + text + "==" + ok);
            }
        }
    }
}
