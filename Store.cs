using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
    class Store
    {
        // member variables (HAS A)
        private double pricePerLemon;
        private double pricePerSugarCube;
        private double pricePerIceCube;
        private double pricePerCup;
        private bool validPurchase;

        // constructor (SPAWNER)
        public Store()
        {
            pricePerLemon = .5;
            pricePerSugarCube = .1;
            pricePerIceCube = .01;
            pricePerCup = .25;
            validPurchase = false;
        }

        // member methods (CAN DO)
        public void SellLemons(Player player)
        {
            int lemonsToPurchase = UserInterface.GetNumberOfItems("lemons");
            double transactionAmount = CalculateTransactionAmount(lemonsToPurchase, pricePerLemon);
            while (validPurchase == false)
            {
                if (player.wallet.Money >= transactionAmount)
                {
                    player.wallet.PayMoneyForItems(transactionAmount);
                    player.inventory.AddLemonsToInventory(lemonsToPurchase);
                    validPurchase = true;
                }
                else
                {
                    UserInterface.UnableToCompletePurchase();
                    lemonsToPurchase = UserInterface.GetNumberOfItems("lemons");
                    transactionAmount = CalculateTransactionAmount(lemonsToPurchase, pricePerLemon);
                }
            }

            validPurchase = false;
        }

        public void SellSugarCubes(Player player)
        {
            int sugarToPurchase = UserInterface.GetNumberOfItems("sugar cubes");
            double transactionAmount = CalculateTransactionAmount(sugarToPurchase, pricePerSugarCube);
            while (validPurchase == false)
            {
                if (player.wallet.Money >= transactionAmount)
                {
                    player.wallet.PayMoneyForItems(transactionAmount);
                    player.inventory.AddSugarCubesToInventory(sugarToPurchase);
                    validPurchase = true;
                }
                else
                {
                    UserInterface.UnableToCompletePurchase();
                    sugarToPurchase = UserInterface.GetNumberOfItems("sugar cubes");
                    transactionAmount = CalculateTransactionAmount(sugarToPurchase, pricePerSugarCube);
                }
            }

            validPurchase = false;
        }

        public void SellIceCubes(Player player)
        {
            int iceCubesToPurchase = UserInterface.GetNumberOfItems("ice cubes");
            double transactionAmount = CalculateTransactionAmount(iceCubesToPurchase, pricePerIceCube);
            while (validPurchase == false)
            {
                if (player.wallet.Money >= transactionAmount)
                {
                    player.wallet.PayMoneyForItems(transactionAmount);
                    player.inventory.AddIceCubesToInventory(iceCubesToPurchase);
                    validPurchase = true;
                }
                else
                {
                    UserInterface.UnableToCompletePurchase();
                    iceCubesToPurchase = UserInterface.GetNumberOfItems("ice cubes");
                    transactionAmount = CalculateTransactionAmount(iceCubesToPurchase, pricePerIceCube);
                }
            }

            validPurchase = false;
        }

        public void SellCups(Player player)
        {
            int cupsToPurchase = UserInterface.GetNumberOfItems("cups");
            double transactionAmount = CalculateTransactionAmount(cupsToPurchase, pricePerCup);
            while (validPurchase == false)
            {
                if (player.wallet.Money >= transactionAmount)
                {
                    player.wallet.PayMoneyForItems(transactionAmount);
                    player.inventory.AddCupsToInventory(cupsToPurchase);
                    validPurchase = true;
                }
                else
                {
                    UserInterface.UnableToCompletePurchase();
                    cupsToPurchase = UserInterface.GetNumberOfItems("cups");
                    transactionAmount = CalculateTransactionAmount(cupsToPurchase, pricePerCup);
                }
            }

            validPurchase = false;
        }

        private double CalculateTransactionAmount(int itemCount, double itemPricePerUnit)
        {
            double transactionAmount = itemCount * itemPricePerUnit;
            return transactionAmount;
        }

        private void PerformTransaction(Wallet wallet, double transactionAmount)
        {
            wallet.PayMoneyForItems(transactionAmount);
        }
    }
}
