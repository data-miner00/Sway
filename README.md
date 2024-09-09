<a name="readme-top"></a>

<!-- PROJECT SHIELDS -->

[![Contributors][contributors-shield]][contributors-url]
[![Forks][forks-shield]][forks-url]
[![Stargazers][stars-shield]][stars-url]
[![Issues][issues-shield]][issues-url]
[![MIT License][license-shield]][license-url]

<!-- PROJECT LOGO -->
<br />
<div align="center">
  <h3 align="center">Sway</h3>

  <p align="center">
	A simple, enterprise-grade, database-first e-commerce platform.
    <br />
    <a href="https://github.com/data-miner00/Sway"><strong>View Demo »</strong></a>
    <br />
    <br />
    <a href="https://github.com/data-miner00/Sway">Explore the docs</a>
    ·
    <a href="https://github.com/data-miner00/Sway/issues">Report Bug</a>
    ·
    <a href="https://github.com/data-miner00/Sway/issues">Request Feature</a>
  </p>
</div>

<!-- TABLE OF CONTENTS -->
<details>
  <summary>Table of Contents</summary>
  <ol>
    <li>
      <a href="#about-the-project">About The Project</a>
      <ul>
        <li><a href="#built-with">Built With</a></li>
      </ul>
    </li>
    <li>
      <a href="#getting-started">Getting Started</a>
      <ul>
        <li><a href="#prerequisites">Prerequisites</a></li>
        <li><a href="#installation">Installation</a></li>
      </ul>
    </li>
    <li><a href="#usage">Usage</a></li>
    <li><a href="#roadmap">Roadmap</a></li>
    <li><a href="#contributing">Contributing</a></li>
    <li><a href="#license">License</a></li>
    <li><a href="#acknowledgments">Acknowledgments</a></li>
  </ol>
</details>

<!-- ABOUT THE PROJECT -->

## About

An experimental e-Commerce platform written in C# and TSQL. This project is for education purpose only as I intentionally shift as much logics to the database as possible. For the entities and database design, please refer to the [drawio document](/docs/Sway.drawio).

<p align="right">(<a href="#readme-top">back to top</a>)</p>

### Built With

The technologies and tools used within this project.

- .NET Core
- .NET MVC
- Pnpm
- TailwindCSS/DaisyUI
- JavaScript
- jQuery
- React
- TSQL/SQL Server
- Powershell
- xUnit

<p align="right">(<a href="#readme-top">back to top</a>)</p>

<!-- GETTING STARTED -->

## Getting Started

### Prerequisites

The list of tools that is used when development.

- [Visual Studio](https://visualstudio.microsoft.com/)
- npm
  ```sh
  npm install npm@latest -g
  ```
- Pnpm
  ```sh
  npm i -g pnpm
  ```
- [Git](https://git-scm.com/downloads)
- [.NET CLI](https://learn.microsoft.com/en-us/dotnet/core/tools/)

### Installation

To run this template project in your local for personal use or contribution, simply perform the following.

1. Clone the repo
   ```sh
   git clone https://github.com/data-miner00/Sway.git
   ```
2. Install Node dependencies
   ```sh
   pnpm i
   ```
3. Restore Nuget
   ```sh
   dotnet restore
   ```
4. Build projects
   ```
   dotnet build
   ```
5. Restore database (steps coming soon..)
6. Run Mvc
   ```
   dotnet run --project src/Sway.Web.Mvc/Sway.Web.Mvc.csproj
   ```

<p align="right">(<a href="#readme-top">back to top</a>)</p>

<!-- ROADMAP -->

## Roadmap

- [ ] Add OAuth/OIDC/Okta authentication
- [ ] Add QRCode
- [ ] Add export history
- [ ] Add notification
- [ ] Use RabbitMQ
- [ ] Use Grafana for telemetry tracking
- [ ] Create GitHub CI
- [ ] Configure code coverage with report generator
- [ ] Create GraphQL API
- [ ] Create API
- [ ] Create Blazor portal
- [ ] Create Mobile App

See the [open issues](https://github.com/data-miner00/Sway/issues) for a full list of proposed features (and known issues).

<p align="right">(<a href="#readme-top">back to top</a>)</p>

<!-- CONTRIBUTING -->

## Contributing

Contributions are what make the open source community such an amazing place to learn, inspire, and create. Any contributions you make are **greatly appreciated**.

If you have a suggestion that would make this better, please fork the repo and create a pull request. You can also simply open an issue with the tag "enhancement".
Don't forget to give the project a star! Thanks again!

1. Fork the Project
2. Create your Feature Branch (`git checkout -b feature/AmazingFeature`)
3. Commit your Changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the Branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

<p align="right">(<a href="#readme-top">back to top</a>)</p>

<!-- LICENSE -->

## License

Distributed under the MIT License. See `LICENSE` for more information.

<p align="right">(<a href="#readme-top">back to top</a>)</p>

<!-- ACKNOWLEDGMENTS -->

## Acknowledgments

List of resources that are helpful and would like to give credit to.

- [.NET](https://dotnet.microsoft.com/en-us/)
- [Add React in One Minute](https://legacy.reactjs.org/docs/add-react-to-a-website.html#add-react-in-one-minute)
- [Using React for a part of your existing page](https://react.dev/learn/add-react-to-an-existing-project#using-react-for-a-part-of-your-existing-page)
- [Babel](https://babeljs.io/docs/presets)

<p align="right">(<a href="#readme-top">back to top</a>)</p>

<!-- MARKDOWN LINKS & IMAGES -->

[contributors-shield]: https://img.shields.io/github/contributors/data-miner00/Sway.svg?style=for-the-badge
[contributors-url]: https://github.com/data-miner00/Sway/graphs/contributors
[forks-shield]: https://img.shields.io/github/forks/data-miner00/Sway.svg?style=for-the-badge
[forks-url]: https://github.com/data-miner00/Sway/network/members
[stars-shield]: https://img.shields.io/github/stars/data-miner00/Sway.svg?style=for-the-badge
[stars-url]: https://github.com/data-miner00/Sway/stargazers
[issues-shield]: https://img.shields.io/github/issues/data-miner00/Sway.svg?style=for-the-badge
[issues-url]: https://github.com/data-miner00/Sway/issues
[license-shield]: https://img.shields.io/github/license/data-miner00/Sway.svg?style=for-the-badge
[license-url]: https://github.com/data-miner00/Sway/blob/master/LICENSE
