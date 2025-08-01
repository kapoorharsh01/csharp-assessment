using System;
using Assignment.VehicleRentalSystem;
using System.Collections.Generic;
using System.Threading;

namespace Assignment.VehicleRentalSystem{

  public interface IRentable{
    
    public void Rent(DateTime start, DateTime end);
    public void ReturnVehicle();
    
  }
  
  public class Vehicle{
    
    private int vehicleId;
    public int VehicleId {get=>vehicleId; set=>vehicleId = value;}

    private string model;
    public string Model {get=>model; set=>model = value;}

    private string brand;
    public string Brand {get=>brand; set=>brand = value;}

    private bool isAvailable = true;
    public bool IsAvailable {get=>isAvailable; set=>isAvailable = value;}

    private int dailyRate;
    public int DailyRate {get=>dailyRate; set=>dailyRate = value;}

    public virtual void DisplayInfo(){
      Console.WriteLine($"ID: {vehicleId}, Model: {model}, Rate: {dailyRate}, Available: {isAvailable}");
    }
  }

  public class Car : Vehicle, IRentable{
    
    private int numOfDoors;
    public int NumOfDoors {get=>numOfDoors; set => numOfDoors = value;}
    
    public override void DisplayInfo(){ // gpt for base
      base.DisplayInfo();
      Console.WriteLine($"No. of Doors :{numOfDoors}");
    }
    
    public void Rent(DateTime start, DateTime end){

      if(!IsAvailable){
        Console.WriteLine("Ops, already rented"); return;
      }
      IsAvailable = false;
      Console.WriteLine($"Car rented from {start:yyyy-MM-dd} to {end:yyyy-MM-dd}"); // gpt for checking syntax for start date & end date

    }
    public void ReturnVehicle(){
      IsAvailable = true;
      Console.WriteLine("Car Returned, Thanks");
    }
  }

  public class Bike : Vehicle, IRentable{
    
    private int engineCapacity;
    public int EngineCapacity {get=>engineCapacity; set => engineCapacity = value;}
    
    public override void DisplayInfo(){
      base.DisplayInfo();
      Console.WriteLine($"Engine Capacity : {engineCapacity}");
    }
    public void Rent(DateTime start, DateTime end){
      
      if(!IsAvailable){
        Console.WriteLine("Ops, already rented"); return;
      }
      
      IsAvailable = false;
      Console.WriteLine($"Bike rented from {start:yyyy-MM-dd} to {end:yyyy-MM-dd}"); 
    }
    
    public void ReturnVehicle(){
      IsAvailable = true;
      Console.WriteLine("Bike Returned, Thanks");
    }
  }
  
  public class Customer{
    
    private int customerId;
    public int CustomerId {get=>customerId; set => customerId = value;}
    
    private string name;
    public string Name {get=>name; set => name = value;}

    private int licenseNumber;
    public int LicenseNumber {get=>licenseNumber; set => licenseNumber = value;}
    
  }

  public class Rental{
    
    private int rentalId;
    public int RentalId {get=>rentalId; set => rentalId = value;}
    
    private Vehicle vehicle; // did gpt for understanding how to pass object in getters & setters
    public Vehicle Vehicle {get=>vehicle; set => vehicle = value;}
    
    private Customer customer;
    public Customer Customer {get=>customer; set => customer = value;}
    
    private DateTime startDate;
    public DateTime StartDate {get=>startDate; set => startDate = value;}
    
    private DateTime endDate;
    public DateTime EndDate {get=>endDate; set => endDate = value;}
    
    private int totalAmount;
    public int TotalAmount {get=>totalAmount; set => totalAmount = value;}

    public decimal CalculateTotal(){
      return (EndDate - StartDate).Days * Vehicle.DailyRate;
    }
  }
}

namespace Assignment{
  
  class Program {
    
    static List<Vehicle> vehicles = new List<Vehicle>(); // gpt for checking the idea of storing info for vehicles n customers n rentals, instead of using LOOPING mechanism on individual variables & fixed sized arrays, this way i found LISTS
    static List<Customer> customers = new List<Customer>();
    static List<Rental> rentals = new List<Rental>();
    
    public static void Main (string[] args) {

      
      Console.WriteLine("Vehicle Rental System");
      Console.WriteLine("1. Add Vehicle");
      Console.WriteLine("2. Register Customer");
      Console.WriteLine("3. Rent Vehicle");
      Console.WriteLine("4. Return Vehicle");
      Console.WriteLine("5. Show Available Vehicles");
      Console.WriteLine("6. Show All Rentals");
      Console.WriteLine("7. Exit");
      
      while(true){
      Console.WriteLine();
      Console.Write("Choose an option: ");
        
      string option = Console.ReadLine();
      
      Console.WriteLine();
        
        switch(option){

        case "1": 
          AddVehicle(); break;
        case "2": 
          RegisterCustomer(); break;
        case "3": 
          RentVehicle(); break;
        case "4": 
          ReturnVehicle(); break;
        case "5": 
          ShowAvailableVehicles(); break;
        case "6": 
          ShowAllRentals(); break;
        case "7": return;

        default: Console.WriteLine("Invalid choice, Try again !"); break;
        }
      }
    }

    static void AddVehicle(){
      
      Console.WriteLine("Enter the type of Vehicle, 1 for CAR & 2 for BIKE");
      string type = Console.ReadLine();

      Console.WriteLine("Enter the Vehicle Id");
      
      if(!int.TryParse(Console.ReadLine(), out int id)){
        Console.WriteLine("Invalid Id");
        return;
      }
      Console.WriteLine("Enter the Brand");
      string brand = Console.ReadLine();

      Console.WriteLine("Enter the Model");
      string model = Console.ReadLine();


      Console.WriteLine("Enter the Daily Rate");

      if(!int.TryParse(Console.ReadLine(), out int rate)){
        Console.WriteLine("Invalid Rate");
        return;
      }

      if(type == "1"){
        Console.WriteLine("Enter the Number of Doors");
        
        if(!int.TryParse(Console.ReadLine(), out int doors)){
          Console.WriteLine("Invalid No. of Doors");
          return;
        }
        Car car = new Car(){
          VehicleId = id,
          Model = model,
          Brand = brand,
          DailyRate = rate,
          NumOfDoors = doors
        };
        vehicles.Add(car);
        Console.WriteLine("Adding Car...");
        Thread.Sleep(3000); // 3 sec delay
        Console.WriteLine("Car added");
      }

      else if(type == "2"){
        
        Console.WriteLine("Enter the Engine Capacity");

        if(!int.TryParse(Console.ReadLine(), out int eCap)){
          Console.WriteLine("Invalid Engine Capacity");
          return;
        }

        Bike bike = new Bike(){
          VehicleId = id,
          Model = model,
          Brand = brand,
          DailyRate = rate,
          EngineCapacity = eCap
        };
        vehicles.Add(bike);
        Console.WriteLine("Adding Bike...");
        Thread.Sleep(3000); // 3 sec delay
        Console.WriteLine("Bike added");
      }
      else{
        Console.WriteLine("Invalid Vehicle Type");
      }
      
    }

    static void RegisterCustomer(){
      
      Console.WriteLine("Enter Customer ID");
      if(!int.TryParse(Console.ReadLine(), out int id)){
        Console.WriteLine("Invalid Customer ID, Try Again !");
      }
      
      Console.WriteLine("Enter your Name");
      string name = Console.ReadLine();
      
      Console.WriteLine("Enter License Number");
      if(!int.TryParse(Console.ReadLine(), out int licenseNo)){
        Console.WriteLine("Invalid License Number, Try Again !");
      }
      
      Customer customer = new Customer{
        CustomerId = id,
        Name = name,
        LicenseNumber = licenseNo
      };
      customers.Add(customer);
      Console.WriteLine("Adding Customer...");
      Thread.Sleep(3000); // 3 sec delay
      Console.WriteLine("Customer Registered");
      
    }

    static void RentVehicle(){
      Console.WriteLine("Enter the Vehicle Id");

      if(!int.TryParse(Console.ReadLine(), out int vId)){
        Console.WriteLine("Invalid Id");
        return;
      }
      
      Console.WriteLine("Enter the Customer Id");

      if(!int.TryParse(Console.ReadLine(), out int cID)){
        Console.WriteLine("Invalid Id");
        return;
      }
      
      Console.WriteLine("Enter the Start Date (yyyy-MM-dd)");

      if(!DateTime.TryParse(Console.ReadLine(), out DateTime start)){
        Console.WriteLine("Invalid format");
        return;
      }
      
      Console.WriteLine("Enter the End Date (yyyy-MM-dd)");

      if(!DateTime.TryParse(Console.ReadLine(), out DateTime end)){
        Console.WriteLine("Invalid format");
        return;
      }

      Vehicle vehicle = vehicles.Find(v => v.VehicleId == vId);
      Customer customer = customers.Find(c => c.CustomerId == cID); 
      // gpt v & c temporarily points to each vehicle's & customer’s reference
      
      if(vehicle == null || customer == null){
        Console.WriteLine("Vehicle or customer not found");
        return;
      }
      
      if(vehicle.IsAvailable && vehicle is IRentable rentable){ /* 
        did gpt for vehicle is IRentable rentable
        is IRentable: Checks if the Car object implements IRentable (it does, because Car has Rent and ReturnVehicle).
        rentable: A new reference to the same Car object, but only lets you use IRentable methods (like rentable.Rent())
        
        Type Restriction: When rentable is declared as IRentable, the program restricts you to the interface’s contract (only Rent and ReturnVehicle).
        Memory: The object (e.g., a Car) has all its methods, but rentable is like a filter that only lets you see and use the IRentable methods.*/

        rentable.Rent(start, end);
        
        Rental rental = new Rental(){
          RentalId = rentals.Count + 1,
          Vehicle = vehicle,
          Customer = customer,
          StartDate = start,
          EndDate = end,
          TotalAmount = (end - start).Days * vehicle.DailyRate
        };
        rentals.Add(rental);
        Console.WriteLine($"Rented {vehicle.Model} to {customer.Name} for ${rental.CalculateTotal()}");
      }
      
      else Console.WriteLine("Vehicle not available or not rentable");
    }
    
    static void ReturnVehicle(){
      
      Console.WriteLine("Enter the Vehicle ID");
      if(!int.TryParse(Console.ReadLine(), out int vId)){
        return;
      }

      Vehicle vehicle = vehicles.Find(v => v.VehicleId == vId);
      
      if(vehicle == null){
        Console.WriteLine("Vehicle not found or not rentable");
        return;
      }

      if(!vehicle.IsAvailable && vehicle is IRentable rentable){
        rentable.ReturnVehicle();
      }
    }
    
    static void ShowAvailableVehicles(){
      
        foreach(Vehicle vehicle in vehicles){
          
          if(vehicle.IsAvailable){
            vehicle.DisplayInfo();
          }
          
        }
    }
    
    static void ShowAllRentals(){
      
      foreach(Rental rental in rentals){
        
        Console.WriteLine($"Rental ID: {rental.RentalId}, Vehicle: {rental.Vehicle.Model}, Customer: {rental.Customer.Name}, Start: {rental.StartDate:yyyy-MM-dd}, End: {rental.EndDate:yyyy-MM-dd}, Total: ${rental.TotalAmount}");
        
      }
    }
  }
}
