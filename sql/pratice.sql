-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- 主機： 127.0.0.1
-- 產生時間： 2026-09-24 06:44:11
-- 伺服器版本： 10.4.32-MariaDB
-- PHP 版本： 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- 資料庫： `pratice`
--

-- --------------------------------------------------------

--
-- 資料表結構 `user`
--

CREATE TABLE `user` (
  `id` int(11) NOT NULL COMMENT '流水號',
  `account` varchar(255) NOT NULL COMMENT '帳號',
  `password` text NOT NULL COMMENT '密碼',
  `Name` varchar(50) NOT NULL COMMENT '暱稱',
  `Email` varchar(255) NOT NULL COMMENT 'email',
  `token` text NOT NULL COMMENT '令牌',
  `expired_date` timestamp NULL DEFAULT NULL COMMENT '到期時間',
  `login_status` int(11) NOT NULL COMMENT '登入狀態(1登入/0登出)'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- 傾印資料表的資料 `user`
--

INSERT INTO `user` (`id`, `account`, `password`, `Name`, `Email`, `token`, `expired_date`, `login_status`) VALUES
(5, 'test', 'e10adc3949ba59abbe56e057f20f883e', '測試', 'test@test.com', '4W2220cM6sDgyz9DJ26EMmQf74Yidyq7Qv/Lglo8bhc=', '2026-09-23 21:11:17', 1),
(6, 'test1', '52852e496f90e1d47c70768642014466', '測試1', 'test1@test.com', '', NULL, 0);

--
-- 已傾印資料表的索引
--

--
-- 資料表索引 `user`
--
ALTER TABLE `user`
  ADD PRIMARY KEY (`id`);

--
-- 在傾印的資料表使用自動遞增(AUTO_INCREMENT)
--

--
-- 使用資料表自動遞增(AUTO_INCREMENT) `user`
--
ALTER TABLE `user`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT COMMENT '流水號', AUTO_INCREMENT=7;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
