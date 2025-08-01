# C# Assessment

## Core Requirements:
Design a basic console-based Vehicle Rental System with the following components:

## 1. Entities & Classes
  * Vehicle (Base class)
      - Properties: VehicleId, Model, Brand, IsAvailable, DailyRate
      - Method: DisplayInfo()
  * Derived classes from Vehicle:
      - Car – Add property: NumOfDoors
      - Bike – Add property: EngineCapacity
  * Customer
      - Properties: CustomerId, Name, LicenseNumber
  * Rental
      - Properties: RentalId, Vehicle, Customer, StartDate, EndDate, TotalAmount
      - Method: CalculateTotal()
    
## 2. Interface
  Create an interface IRentable with the following methods:
    - Rent(DateTime start, DateTime end)
    - ReturnVehicle()
  Implement this interface in Car and Bike.

## 3. Functional Requirements
  - Add vehicles to the system.
  - Register customers.
  - Rent a vehicle (if available) to a customer.
  - Return a vehicle.
  - Show list of available vehicles.
  - Display all rentals with total amount and duration.
    
## 4. OOP Concepts to Use
  - Encapsulation: Use private fields with getters/setters.
  - Inheritance: Car and Bike inherit from Vehicle.
  - Polymorphism: Override DisplayInfo() in Car and Bike.
  - Interfaces: Implement IRentable in vehicle classes.
