// Copyright (c) .NET Foundation and contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace CookBook.DAL.Migrator;

public interface IDbMigrator
{
    public void Migrate();
    public Task MigrateAsync(CancellationToken cancellationToken);
}
