using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaStuff
{
    public class Pizzeria
    {
        // Склад для ингредиентов. Хранит количество каждого ингредиента.
        private Dictionary<Ingredients, int> storage = new Dictionary<Ingredients, int>();

        /// <summary>
        /// Привозит новые ингредиенты на склад.
        /// Увеличивает количество ингредиента ingredients на значение amount.
        /// </summary>
        /// <param name="ingredients"> Ингредиент, который будет привезен на склад. </param>
        /// <param name="amount"> Количество ингредиента. </param>
        public void DeliverIngredient(Ingredients ingredients, int amount)
        {
            if (storage.ContainsKey(ingredients))
            {
                storage[ingredients] += amount;
            }
            else
            {
                storage[ingredients] = amount;
            }
        }

        /// <summary>
        /// Возвращет информацию о количестве каждого ингредиента на складе.
        /// </summary>
        public (string name, int amount)[] GetStorage()
        {
            var a = storage.ToArray();
            (string name, int amount)[] b = new (string name, int amount)[a.Length];
            for (int i = 0; i < a.Length; i++)
            {
                b[i] = (a[i].Key.ToString(), a[i].Value);
                Console.WriteLine((a[i].Key.ToString(), a[i].Value));
            }
            return b;
        }

        /// <summary>
        /// Готовит пиццу по рецепту.
        /// </summary>
        /// <param name="recipe"> Рецепт пиццы. </param>
        /// <returns> Приготовленная пицца. </returns>
        /// <exception cref="PizzaException"> Если на складе не хватает ингредиентов, чтобы приготовить пиццу по рецепту.</exception>
        public Pizza MakePizza(PizzaRecipe recipe)
        {
            bool flag = HasIngredients(recipe);
            if (!flag)
            {
                throw new PizzaException("");
            }
            else
            {
                UseIngredients(recipe);
                Pizza pizza = new Pizza(recipe);
                return pizza;
            }
        }

        /// <summary>
        /// Проверяет, есть ли на складе ингредиенты для рецепта.
        /// </summary>
        /// <param name="recipe"> Рецепт, наличие ингредиентов необходимо проверить. </param>
        /// <returns> true, если все ингредиенты есть на складе, false иначе. </returns>
        private bool HasIngredients(PizzaRecipe recipe)
        {
            bool flag = true;
            Ingredients required = recipe.Ingredients;
            foreach (Ingredients item in Enum.GetValues(typeof(Ingredients)))
            {
                try
                {
                    if ((item & required) != 0 && storage[item] == 0)
                    {
                        flag = false;
                        break;
                    }
                }
                catch
                {
                    flag = false;
                    break;
                }
            }
            return flag;
        }

        /// <summary>
        /// Удаляет со склада по одному ингредиенту из рецепта.
        /// </summary>
        /// <param name="recipe"></param>
        private void UseIngredients(PizzaRecipe recipe)
        {
            Ingredients required = recipe.Ingredients;
            foreach (Ingredients item in Enum.GetValues(typeof(Ingredients)))
            {
                if ((item & required) != 0)
                {
                    storage[item] -= 1;
                }
            }
        }
    }
}
