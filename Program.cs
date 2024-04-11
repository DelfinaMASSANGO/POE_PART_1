using System;

namespace POE_PART_1
{
    class Step //This is the steps of the recipe 
    {
        public string Description { get; set; } //this is where i will be describing my steps of the recipe 
    }

    class Recipe //This is the recipe 
    {
        private Ingredient[] ingredients; // this is the array to store the ingredients 
        private Step[] steps; // this is an array to store the steps that will entered by the user 

        public void CreateRecipe()// this is a method for the user to be able to creat a recipe 
        {
            Console.Write("Enter the number of ingredients to be used: ");
            int numIngredients = int.Parse(Console.ReadLine());
            ingredients = new Ingredient[numIngredients]; // This actuyally Initializes the ingredients array i added on line 12
            Console.WriteLine();
            for (int i = 0; i < numIngredients; i++) ; // this is a loop to input details for each ingredient 
            {
                Console.WriteLine($"Enter details for ingredient {i + 1}:");
                Console.Write("Name of the ingredient: ");
                string name = Console.ReadLine();
                Console.WriteLine();
                Console.Write("Quantity you want to use: ");
                double quantity = double.Parse(Console.ReadLine());
                Console.WriteLine();
                Console.Write("Unit that will be used: ");
                string unit = Console.ReadLine();
                Console.WriteLine();
                ingredients[i] = new Ingredient { Name = name, Quantity = quantity, Unit = unit, OriginalQuantity = quantity };
            }

            Console.Write("Enter the number of steps you need: ");
            int numSteps = int.Parse(Console.ReadLine());
            steps = new Step[numSteps];

            for (int i = 0; i < numSteps; i++)
            {
                Console.Write($"Enter step description {i + 1}: ");
                string description = Console.ReadLine();
                steps[i] = new Step { Description = description };
            }
            Console.WriteLine();
            Console.WriteLine("Congatulations!! Your recipe has beeb created successfully.");
        }

        class Ingredient
        {
            public string Name { get; set; }
            public double Quantity { get; set; }
            public string Unit { get; set; }
            public double OriginalQuantity { get; set; }
        }

        public void DisplayRecipe()
        {
            if (ingredients == null || steps == null)
            {
                Console.WriteLine("Dear user you have not created a recipe yet.");
                return;
            }

            Console.WriteLine("Recipe:");
            Console.WriteLine();
            Console.WriteLine("Ingredients:");
            foreach (var ingredient in ingredients)
            {
                Console.WriteLine($"{ingredient.Quantity} {ingredient.Unit} of {ingredient.Name}");
            }

            Console.WriteLine("\nSteps:");
            for (int i = 0; i < steps.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {steps[i].Description}");
            }
        }

        public void ScaleRecipe(double factor)
        {
            if (ingredients == null)
            {
                Console.WriteLine("Dear user you have not created recipe yet.");
                return;
            }

            foreach (var ingredient in ingredients)
            {
                ingredient.Quantity *= factor;
            }

            Console.WriteLine($"Your recipe has been scaled by a factor of {factor}.");
        }

        public void ResetQuantities()
        {
            if (ingredients == null)
            {
                Console.WriteLine("No recipe created yet.");
                return;
            }

            for (int i = 0; i < ingredients.Length; i++)
            {
                ingredients[i].Quantity = ingredients[i].OriginalQuantity;
            }

            Console.WriteLine("The quantities of your recipe have been reset successfully.");
        }

        public void ClearRecipe()
        {
            ingredients = null;
            steps = null;
            Console.WriteLine("The Recipe cleared successfully.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Recipe recipe = new Recipe();
            Console.WriteLine("<=============WELCOME TO DELFINA'S RECIPE CREATOR=============>");
            Console.WriteLine("----------------Making The Kitchen Life Easier-----------------");
            while (true)
            {
                Console.WriteLine("\n1. Create a Recipe");
                Console.WriteLine("2. Show the Recipe");
                Console.WriteLine("3. Scale the Recipe");
                Console.WriteLine("4. Reset the Quantities");
                Console.WriteLine("5. Clear your Recipe");
                Console.WriteLine("6. Exit");
                Console.Write("please select an option: ");

                try
                {
                    int option = int.Parse(Console.ReadLine());

                    switch (option)
                    {
                        case 1:
                            recipe.CreateRecipe();
                            break;
                        case 2:
                            recipe.DisplayRecipe();
                            break;
                        case 3:
                            Console.Write("Enter scale factor (0.5, 2, or 3): ");
                            double factor = double.Parse(Console.ReadLine());
                            recipe.ScaleRecipe(factor);
                            break;
                        case 4:
                            recipe.ResetQuantities();
                            break;
                        case 5:
                            recipe.ClearRecipe();
                            break;
                        case 6:
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Oops! Invalid option. Please try again.");
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Oops! That was an invalid option. Please try again!.");
                }
            }
        }
    }
}

