# ApplicationForm

This is a .NET Core Web API project for managing application forms, including creating, updating, and retrieving questions for an employer's program, as well as allowing candidates to apply for the program.

## Table of Contents

- [Overview](#overview)
- [Features](#features)
- [Technologies](#technologies)
- [Setup](#setup)
- [Usage](#usage)
- [API Endpoints](#api-endpoints)
- [Testing](#testing)
- [License](#license)

## Overview

The ApplicationForm project consists of two main controllers:
1. **ApplicantsController**: Manages applications submitted by candidates.
2. **EmployerQuestionController**: Manages questions created by employers for their programs.

## Features

- Employers can create, update, and retrieve questions of different types.
- Candidates can apply for programs and submit their responses to questions.
- Questions can be filtered by type.
- Error handling for not found resources.

## Technologies

- .NET Core
- ASP.NET Core Web API
- Azure Cosmos DB (NoSQL)
- AutoMapper
- xUnit (for unit testing)
- Moq (for mocking in tests)
- Swagger (for API documentation)

## Setup

### Prerequisites

- [.NET Core SDK](https://dotnet.microsoft.com/download)
- [Azure Cosmos DB Emulator](https://docs.microsoft.com/en-us/azure/cosmos-db/local-emulator) (for local development and testing)
### Installation

1. Clone the repository:
   ```bash
   git clone https://github.com/yourusername/ApplicationForm.git
   cd ApplicationForm
Install the required packages:

License
This project is licensed under the MIT License. See the LICENSE file for details.

### Explanation

1. **Overview**: Provides a brief summary of what the project does.
2. **Features**: Lists the main features of the application.
3. **Technologies**: Lists the main technologies used.
4. **Setup**: Includes prerequisites, installation steps, and how to configure the application.
5. **Usage**: Describes how to use Swagger for API documentation and how to run the Cosmos DB Emulator.
6. **API Endpoints**: Describes the available API endpoints with their methods, descriptions, and expected payloads or responses.
7. **Testing**: Explains how to run the unit tests and where they are located.
8. **License**: Mentions the licensing of the project. 

This `README.md` file should help anyone understand the project setup, usage, and struct
