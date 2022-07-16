﻿namespace IntoOOP.Draw;

/// <summary>Класс, описывающий фигуру.</summary>
public class Figure
{
    /// <summary>Позиция фигуры.</summary>
    public Vector Pos { get; set; } 

    /// <summary>Цвет фигуры.</summary>
    public ConsoleColor Color { get; set; }

    /// <summary>Видимость фигуры.</summary>
    public bool IsHidden { get; set; }

    /// <summary>Приведение объекта фигуры к строке с информацией об объекте фигуры.</summary>
    /// <returns>Cтрока с информацией об объекте фигуры.</returns>
    public override string ToString() => 
        $"Figure\r\n\tPosition = {Pos}\r\n\tColor = {Color}\r\n\tIsHidden = {IsHidden}";
}
