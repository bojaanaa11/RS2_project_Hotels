# Hotels


The Hotels project is a hotel room management system. It allows guests to easily search for 
hotels, book rooms, and rate their stay afterward. For administrators, the system provides tools to manage 
guest check-ins and check-outs. They can also add new rooms and handle other day-to-day hotel 
operations.

The Hotels project is structured as a microservices-based application. It utilizes microservices 
architecture to independently deploy and scale components such as Identity, Rooms Management, Reservations, 
Check-In/Check-Out, and Rating. These microservices communicate using gRPC and RabbitMQ. Additionally, 
the project includes a dynamic frontend developed in Angular (HotelsSPA), providing an intuitive 
user interface for guests and administrators.

## Required software
- .NET 6
- Docker
- Node.js
- Angular (for HotelsSPA)

## Running the application
Run docker compose in the solution directory:
```sh
docker-compose -f ./docker-compose.yml -f ./docker-compose.override.yml up -d --build
```

Start the client:
```sh
cd WebApps/HotelsSPA/
npm install
npm run dev
```

To stop the application run:
```sh
docker-compose -f ./docker-compose.yml -f ./docker-compose.override.yml down
```

## Services

### Identity
The Identity microservice manages both user accounts and roles. 
Authentication is performed using JWT and refresh tokens, while roles are used for authorization. 
The supported roles include Hotel Administrator and Hotel Guest.

### Managing Rooms
The Rooms Management Microservice allows administrators to add and update hotels and rooms. 
Guests can use it to search for hotels, check room availability, and make reservations.
The ManagingRooms microservice leverages gRPC communication to interact with the Reservations microservice, 
facilitating the transfer of hotel and room lists. This microservice ensures efficient data handling 
and real-time updates by using Redis as its database.

### Reservations

The Reservations Microservice is designed to facilitate the booking process for hotel guests. It allows guests 
to easily make reservations for their chosen rooms and hotels. Additionally, it keeps track of all current
reservations, allowing guests to review and manage their bookings as needed. 

### Check in and check out
The Check-In and Check-Out Microservice enables administrators to manage guest arrivals and departures. 
Administrators verify reservations through gRPC communication with the Reservations Microservice 
to check in guests. Upon check-out, the microservice initiates an asynchronous message to both the Rating and 
Reservations Microservices. This will allow guests to provide feedback and rate their stay.

### Rating
The Rating Microservice enhances guest experience by receiving asynchronous message from the Check-In and 
Check-Out Microservice upon guest check-out, enabling guests to provide feedback and rate their stay. 
Additionally, when guests browse hotels, they can view average ratings and comments, 
facilitating informed decisions based on previous guest experiences.


## Authors
- Bojana Obradović, 1065/2023
- Isidora Burmaz, 1057/2023
- Aleksandra Biočanin, 21/2019

