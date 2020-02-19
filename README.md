# Instruction Manual <!-- omit in toc -->

## Table of contents <!-- omit in toc -->

- [1 Introduction](#1-introduction)
- [2 Project Setup](#2-project-setup)
  - [2.1 Software Requirements](#21-software-requirements)
  - [2.2 Cloning the repository](#22-cloning-the-repository)
  - [2.3 GitHub Desktop](#23-github-desktop)
- [3 Coding standards](#3-coding-standards)
  - [3.1 Naming Conventions](#31-naming-conventions)
    - [3.1.1 Definitions](#311-definitions)
    - [3.1.2 Conventions](#312-conventions)
- [4 Git Branching Strategy](#4-git-branching-strategy)
- [5 Pull Requests](#5-pull-requests)
- [6 Testing Strategy](#6-testing-strategy)
  - [6.1 Manual Testing](#61-manual-testing)
  - [6.2 Unit Testing](#62-unit-testing)
  - [6.3 Regression Testing](#63-regression-testing)
  - [6.4 Validation Testing](#64-validation-testing)
  - [6.5 Beta Testing](#65-validation-testing)
- [7 Metrics](#7-metrics)
- [8 Test Driven Development](#8-test-driven-development)
  
## 1 Introduction

The first section of this document outlines how to setup a local development environment in Unity on a Windows operating system. The second section outlines conventions to follow when working on this project.

Please follow these instructions carefully.

## 2 Project Setup

### 2.1 Software Requirements

This project requires the following software to be installed:

- [Unity Version 2018.2.0f2](https://store.unity.com/download)
- [GitHub Desktop](https://desktop.github.com)
- [git](https://git-scm.com/)

### 2.2 Cloning the repository

* Open the command prompt by clicking on the search button and typing `cmd`
* Create a new folder. `mkdir git`
* Navigate to the new folder. `cd git` 
* Clone the repository. `git clone https://github.com/acerasoni/DropArena.git`
* Open Unity -> "Add" -> Select the "DropArena" folder inside the repository you just cloned.

### 2.3 GitHub Desktop

For contributions to the projects we will use GitHub Desktop, a free tool which allows you to perform git operations through a convenient graphical interface. To setup, open GitHub Desktop and login via your GitHub account. From there, import the repository cloned above.

## 3 Coding standards

Below are the set of C# standards and practices you must follow when contributing to the codebase. Although tedious to follow, coding conventions serve the following purposes:

* They create a consistent look to the code, so that readers can focus on content, not layout.
* They enable readers to understand the code more quickly by making assumptions based on previous experience.
* They facilitate copying, changing, and maintaining the code.
* They demonstrate C# best practices.

If unsure, visit [Microsoft's C# Coding Conventions](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/inside-a-program/coding-conventions) for practical examples.

### 3.1 Naming Conventions

#### 3.1.1 Definitions

* Camel Case (camelCase): In this standard, the first letter of the word always in small letter and after that each word starts with a capital letter.
* Pascal Case (PascalCase): In this the first letter of every word is in capital letter.
* Underscore Prefix (_underScore): For underscore ( __ ), the word after _ use camelCase terminology.

#### 3.1.2 Conventions

* For public variables, use Camel Case.
* For method parameters, use Camel Case.
* For private variables, use Underscore Prefix.
* For methods, use Pascal Case.
* For class names, use Pascal Case.

### 3.2 Layout Conventions

* Good layout uses formatting to emphasize the structure of your code and to make the code easier to read.
* Write only one statement per line.
* Write only one declaration per line.
* If continuation lines are not indented automatically, indent them one tab stop.
* Add at least one blank line between method definitions and property definitions.
* Use parentheses to make clauses in an expression apparent, as shown in the following code.

### 3.3 Commenting Conventions

* Commenting Conventions
* Place the comment on a separate line, not at the end of a line of code.
* Begin comment text with an uppercase letter.
* End comment text with a period.

## 4 Git Branching Strategy

There are 4 branch tiers called: Production, Development, Feature, Bugfix, Refactoring.

1. Production (called `production`)
   - Merged from develop at the end of each sprint

2. Development (called `develop`)
   - Merged from each feature or bugfix branch when completed

3. Feature (called `feature/xxxx`)
   - Merges into develop
  
4. Bugfix (called `bugfix/xxxx`)
   - Merges into either develop or feature branch
   
4. Refactor (called `refactor/xxxx`)
   - Merges into either develop or feature branch
   
## 5 Pull Requests

When your feature is completed, please *do not* merge into develop. Instead, navigate to GitHub and click 'Pull Requests'. From there, click 'Open Pull Request'. Select your branch on the right and develop on the left. On the right hand side of the page, select all other team members as reviewers. Then, navigate to the bottom of the page and open the Pull Request. Once enough people reviewed the code, the Pull Request will be merged into develop.

## 6 Testing Strategy

When a feature is completed, please perform the below testing before opening a Pull Request.

### 6.1 Manual Testing

Ensure through manual testing that your code behaves exactly as expected, and that no bugs are present. The expected behaviour will differ for each feature, however please ensure all the requirements for that ticket are met.

### 6.2 Unit Testing

For this project we will be doing Use Case testing. Refer to the [Testing Spreadsheet](https://docs.google.com/spreadsheets/d/11tIiyM8mKgFMOB6ftfkC5HgAkqNT2-T9nuL2GRtHgfc/edit#gid=0) for examples and instructions.

### 6.3 Regression Testing

Any changes introduced by your new feature, in addition to be fully covered by unit tests, will require you to perform regression testing. That is, you will have to perform *all* previous unit tests to ensure they pass. If any of them breaks, you will have to either introduce the fix on your current branch, or create a bugfix branch. Nevertheless, the feature will not be ready for Pull Request until:

* Manual Testing successfully proves all requirements for the ticket are met
* Unit Testing covers all of the new functionality
* Regression Testing passes, proving the new changes don't break old functionality

### 6.4 Validation Testing

Validation testing provides final assurance that the software meets all client requirements. We will perform validation testing at the end of each sprint as part of our sprint retro. The client will join the sprint retros, to ensure that requirements are kept up to date. Then, our developers will ensure that the code meets these requirements.

### 6.5 Beta Testing

At the end of the project, we will run Beta Testing as described in the lectures. The deadline for this activity is set to the 1st of March.  

## 7 Metrics

We will keep track of two Metrics during development. These will be computed at the end of each sprint from the `develop` branch, which will be used to produce metrics graphs.

* LOC: Lines of Code for the entire project
* Test Coverage: The % of methods covered by use case tests.

## 8 Test Driven Development

Usually, you can write unit tests after you have manually validated your code. However, in some occasions, we will be doing Test Driven Development and Pair Programming. Please look at the recording of [Lecture 8](https://moodle.nottingham.ac.uk/mod/resource/view.php?id=4086887) for a detailed explaination on what TDD is. When working in pair, you will have to include the initials of both people in your commits. For example,

`git commit -m "feature001: A&J, Created new sphere object"`
