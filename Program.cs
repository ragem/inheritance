using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inheritance
{
    
    class Program
    {
       static Random rdn = new Random();
      static  string[] GetV = new string[] { "Child", "Child", "Child", "Child", "Child", "Student", "Student", "Pupil", "Pupil", "Pupil" };
        static string[] designation = new string[] {"Rigas","Latvijas","Jelgavas","Madonas","Daugavpils","Ogres","Rigas Valsts","Valmieras","Siguldas","Kekeavas" };
        static string[] types = new string[] {"Tehnikums","Vidusskola","Pamatskola","Gimnazija","Sakumskola","Licejs","Privatskola","Universitate","Koledza" };
        static string[] letters = new string[] { "a","b","c","d","e","f","g" };


        static string[,] berni = new string[10, 4];
        static void Main(string[] args)
        {

            for(int i=0; i<10;i++)
            {
                 string decider = GetV[rdn.Next(0, GetV.Length)];
                berni[i, 0] = decider;
                if (decider == "Child") berni[i, 1] = rdn.Next(1, 7).ToString();
                else if (decider == "Pupil") berni[i, 1] = rdn.Next(5, 20).ToString();
                else berni[i, 1] = rdn.Next(17, 70).ToString();
                string randschooldesigandnumb = designation[rdn.Next(0, designation.Length)] + " " + rdn.Next(1, 100).ToString();
                string randschooltype = types[rdn.Next(0, types.Length)];
                string randschoolclass;
                if ((randschooltype == "Tehnikums") || (randschooltype == "Koledza") || (randschooltype == "Universitate")) randschoolclass = rdn.Next(1, 4).ToString() + ". kurss";
                else if ((randschooltype == "sakumskola")) randschoolclass = rdn.Next(1, 6).ToString() + "."+ letters[rdn.Next(0, letters.Length)]+" klase";
                else if ((randschooltype == "Pamatskola")) randschoolclass = rdn.Next(1, 9).ToString() + "." + letters[rdn.Next(0, letters.Length)] + " klase";
                else  randschoolclass = rdn.Next(1, 12).ToString() + "." + letters[rdn.Next(0, letters.Length)] + " klase";
                berni[i, 2] = randschooldesigandnumb + ". " + randschooltype;
                berni[i, 3] = randschoolclass;
            }

            Child child = new Child("jevgenij","lazlojajevich",12);
            child.growolder();
            Student student = new Student("stanislav","polnij",21,"moskovskaja pravoslavnaja shkola","medicinskij fakultet","12");
            student.growolder();
            Pupil pupil = new Pupil("maksim","orbitaev",15,"vladivostochanaja gimnazija","9tij klass");
            pupil.growolder();
            


          Console.WriteLine(child.returner());
            Console.WriteLine(student.returner());
            Console.WriteLine(pupil.returner());
            Console.WriteLine("\n");
            for(int i=0;i<10;i++)
            {
                Console.WriteLine(berni[i,0]+" is "+berni[i,1]+"years old and studies at "+berni[i,2]+" in "+berni[i,3]);
            }


            Console.ReadLine();
        }
    }

    public class Child
    {
        protected string name;
        protected string surnam;
        protected int age;
        public Child()
        {
            name = "vladislav";
            surnam = "preschivskij";
            age = 0;
        }

        public Child(string aname, string asurnam, int aage)
        {
            name = aname;
            surnam = asurnam;
            age = aage;
        }

        public Tuple<string, string, string, int> returner()
        {

            return Tuple.Create(this.GetType().Name.ToString(), name, surnam, age);
        }
        public void growolder()
        {
            age++;
        }
    }

    public class Student : Child
    {
        protected string HS;
        protected string faculty;
        protected string year;
        public Student(string aname, string asurnam, int aage,string aHS,string afaculty, string ayear) : base(aname, asurnam, aage)
        {
            name = aname;
            surnam = asurnam;
            age = aage;
            HS = aHS;
            faculty = afaculty;
            year = ayear;

        }

        public Tuple<string, string, string, int, string, string,string> returner()
        {

            return Tuple.Create(this.GetType().Name.ToString(), name, surnam, age, HS, faculty,year);
        }

    }

    public class Pupil : Child
    {
        protected string school;
        protected string clas;

        public Pupil(string aname, string asurnam, int aage,string aschool,string aclas)  : base(aname,  asurnam,  aage)
        {
            name = aname;
            surnam = asurnam;
            age = aage;
            clas = aclas;
            school = aschool;
        }

        public Tuple<string,string, string, int,string,string> returner()
        {

            return Tuple.Create(this.GetType().Name.ToString(), name, surnam, age,clas,school);
        }
    }
}
