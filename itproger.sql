-- phpMyAdmin SQL Dump
-- version 5.0.2
-- https://www.phpmyadmin.net/
--
-- Хост: 127.0.0.1:3306
-- Время создания: Дек 07 2020 г., 01:29
-- Версия сервера: 8.0.19
-- Версия PHP: 7.1.33

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- База данных: `itproger`
--

-- --------------------------------------------------------

--
-- Структура таблицы `users`
--

CREATE TABLE `users` (
  `id` int UNSIGNED NOT NULL,
  `login` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `pass` varchar(32) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `Name` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `Famil` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `Otche` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `Admin` varchar(1) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `Valutka` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `users`
--

INSERT INTO `users` (`id`, `login`, `pass`, `Name`, `Famil`, `Otche`, `Admin`, `Valutka`) VALUES
(1, 'admin', '123', 'oleg', '314', '13431', '1', '0'),
(2, 'Jake', '123', 'Jony', 'Lof', 'Gen', '0', '0'),
(6, 'newadmin', '123', '231', '4134', '41431', '1', '0'),
(15, 'lolik', '123', 'sda', 'afda', 'fdafad', '2', '321321');

-- --------------------------------------------------------

--
-- Структура таблицы `zapic`
--

CREATE TABLE `zapic` (
  `id` int UNSIGNED NOT NULL,
  `nameZ` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `uid` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `vidwork` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `mark` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `date` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `idAv` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `nameAv` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `Payment` varchar(255) NOT NULL,
  `Status` varchar(1) NOT NULL,
  `idAvu` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `zapic`
--

INSERT INTO `zapic` (`id`, `nameZ`, `uid`, `vidwork`, `mark`, `date`, `idAv`, `nameAv`, `Payment`, `Status`, `idAvu`) VALUES
(57, '2', '2', '2', '2', '2', '15', 'sda', '0', '1', '15'),
(55, '32131', '2', '321312', '21312', '123213', '0', '0', '0', '0', '0');

--
-- Индексы сохранённых таблиц
--

--
-- Индексы таблицы `users`
--
ALTER TABLE `users`
  ADD UNIQUE KEY `id` (`id`);

--
-- Индексы таблицы `zapic`
--
ALTER TABLE `zapic`
  ADD UNIQUE KEY `id` (`id`);

--
-- AUTO_INCREMENT для сохранённых таблиц
--

--
-- AUTO_INCREMENT для таблицы `users`
--
ALTER TABLE `users`
  MODIFY `id` int UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=16;

--
-- AUTO_INCREMENT для таблицы `zapic`
--
ALTER TABLE `zapic`
  MODIFY `id` int UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=58;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
