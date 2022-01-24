namespace System.Windows;

/// <summary>
/// Представляет метод, который обрабатывает общие события.
/// </summary>
/// <typeparam name="TSender">
/// Тип источника события.
/// </typeparam>
/// <typeparam name="TResult">
/// Тип данных события.
/// </typeparam>
/// <param name="sender">
/// Источник события.
/// </param>
/// <param name="args">
/// Данные события. Если данные о событии отсутствуют, этот параметр будет иметь значение <see langword="null"/>.
/// </param>
public delegate void TypedEventHandler<TSender, TResult>(TSender sender, TResult args);
