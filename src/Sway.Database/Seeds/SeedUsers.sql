-- ------------------------------------------------------------------------------
-- <auto-generated>
-- This is the seeder file for User.
-- Generated on 28/7/2024.
-- </auto-generated>
-- ------------------------------------------------------------------------------

USE [Sway];


EXEC usp_CreateNewUser
    @Username = 'Lizzie Mante',
    @FirstName = 'Lizzie',
    @LastName = 'Mante',
    @DateOfBirth = '2023-08-28',
    @Email = 'Lizzie.Mante@gmail.com',
    @Phone = '1-416-247-4496 x933',
    @PhotoUrl = 'https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/503.jpg',
    @Description = 'Hi, I am Lizzie Mante',
    @PasswordHash = 'TemporaryHash',
    @PasswordSalt = 'TemporarySalt',
    @HashAlgorithm = 'sha256';

EXEC usp_CreateNewUser
    @Username = 'Claude Kuhic',
    @FirstName = 'Claude',
    @LastName = 'Kuhic',
    @DateOfBirth = '2023-09-23',
    @Email = 'Claude21@gmail.com',
    @Phone = '1-801-651-5438 x8391',
    @PhotoUrl = 'https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/1023.jpg',
    @Description = 'Hi, I am Claude Kuhic',
    @PasswordHash = 'TemporaryHash',
    @PasswordSalt = 'TemporarySalt',
    @HashAlgorithm = 'sha256';

EXEC usp_CreateNewUser
    @Username = 'Baylee Schaefer',
    @FirstName = 'Baylee',
    @LastName = 'Schaefer',
    @DateOfBirth = '2024-05-31',
    @Email = 'Baylee_Schaefer@gmail.com',
    @Phone = '353-719-2339',
    @PhotoUrl = 'https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/904.jpg',
    @Description = 'Hi, I am Baylee Schaefer',
    @PasswordHash = 'TemporaryHash',
    @PasswordSalt = 'TemporarySalt',
    @HashAlgorithm = 'sha256';

EXEC usp_CreateNewUser
    @Username = 'Aurelia Thompson',
    @DateOfBirth = '2023-08-08',
    @Email = 'Aurelia.Thompson@hotmail.com',
    @Phone = '364.821.2185',
    @PhotoUrl = 'https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/382.jpg',
    @Description = 'Hi, I am Aurelia Thompson',
    @PasswordHash = 'TemporaryHash',
    @PasswordSalt = 'TemporarySalt',
    @HashAlgorithm = 'sha256';

EXEC usp_CreateNewUser
    @Username = 'Dariana Ziemann',
    @FirstName = 'Dariana',
    @LastName = 'Ziemann',
    @DateOfBirth = '2023-08-08',
    @Email = 'Dariana_Ziemann@gmail.com',
    @Phone = '(563) 392-9249',
    @PhotoUrl = 'https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/757.jpg',
    @Description = 'Hi, I am Dariana Ziemann',
    @PasswordHash = 'TemporaryHash',
    @PasswordSalt = 'TemporarySalt',
    @HashAlgorithm = 'sha256';
