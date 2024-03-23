﻿namespace Cargo.Application.Contracts.Logging;

public interface IAppLogger<T>
{
    void LogInformation(string message, params object[] args);
    void LogWarning(string message, params object[] args);
    void LogCritical(string message, params object[] args);
}
