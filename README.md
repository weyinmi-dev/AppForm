# ApplicationForm

This is a .NET Core Web API project for managing application forms, including creating, updating, and retrieving questions for an employer's program, as well as allowing candidates to apply for the program.

## Table of Contents

- [Overview](#overview)
- [Features](#features)
- [Technologies](#technologies)
- [Setup](#setup)

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
   git clone https://github.com/weyinmi-dev/AppForm.git
   cd ApplicationForm

License
This project is licensed under the MIT License. 

