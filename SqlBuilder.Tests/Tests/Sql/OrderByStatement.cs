﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using SqlBuilder.Sql;

namespace SqlBuilder.Tests
{

	[TestClass]
	public class OrderByStatement
	{

		[TestMethod]
		[TestCategory("OrderBy")]
		public void OrderByASCSimple1()
		{
			SqlBuilder.DefaultFormatter = FormatterLibrary.MsSql;

			OrderByList o = new OrderByList(SqlBuilder.DefaultFormatter);
			o.Ascending("a");
			string result = o.GetSql();
			string sql = "[a] ASC";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("OrderBy")]
		public void OrderByASCSimple2()
		{
			SqlBuilder.DefaultFormatter = FormatterLibrary.MsSql;

			OrderByList o = new OrderByList(SqlBuilder.DefaultFormatter);
			o.Ascending("a", "b", "c");
			string result = o.GetSql();
			string sql = "[a] ASC, [b] ASC, [c] ASC";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("OrderBy")]
		public void OrderByDESCSimple1()
		{
			SqlBuilder.DefaultFormatter = FormatterLibrary.MsSql;

			OrderByList o = new OrderByList(SqlBuilder.DefaultFormatter);
			o.Descending("a");
			string result = o.GetSql();
			string sql = "[a] DESC";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("OrderBy")]
		public void OrderByDESCSimple2()
		{
			SqlBuilder.DefaultFormatter = FormatterLibrary.MsSql;

			OrderByList o = new OrderByList(SqlBuilder.DefaultFormatter);
			o.Descending("a", "b", "c");
			string result = o.GetSql();
			string sql = "[a] DESC, [b] DESC, [c] DESC";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("OrderBy")]
		public void OrderByASCAndDESC1()
		{
			SqlBuilder.DefaultFormatter = FormatterLibrary.MsSql;

			OrderByList o = new OrderByList(SqlBuilder.DefaultFormatter);
			o.Ascending("a");
			o.Descending("b");
			o.Ascending("c");
			o.Descending("d");
			string result = o.GetSql();
			string sql = "[a] ASC, [b] DESC, [c] ASC, [d] DESC";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("OrderBy")]
		public void OrderByASCAndDESC2()
		{
			SqlBuilder.DefaultFormatter = FormatterLibrary.MsSql;

			OrderByList o = new OrderByList(SqlBuilder.DefaultFormatter);
			o.Ascending("a", "b", "c");
			o.Descending("d", "e", "f");
			string result = o.GetSql();
			string sql = "[a] ASC, [b] ASC, [c] ASC, [d] DESC, [e] DESC, [f] DESC";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("OrderBy")]
		public void OrderByASCAndDESCAlias()
		{
			SqlBuilder.DefaultFormatter = FormatterLibrary.MsSql;

			OrderByList o = new OrderByList(SqlBuilder.DefaultFormatter);
			o.Ascending("a");
			o.Descending("b");
			o.Ascending("c");
			o.Descending("d");
			string result = o.GetSql("t");
			string sql = "[t].[a] ASC, [t].[b] DESC, [t].[c] ASC, [t].[d] DESC";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("OrderBy")]
		public void OrderByRaw1()
		{
			SqlBuilder.DefaultFormatter = FormatterLibrary.MsSql;

			OrderByList o = new OrderByList(SqlBuilder.DefaultFormatter);
			o.Raw("[c] ASC, [d] DESC");
			string result = o.GetSql("t");
			string sql = "[c] ASC, [d] DESC";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("OrderBy")]
		public void OrderByRaw2()
		{
			SqlBuilder.DefaultFormatter = FormatterLibrary.MsSql;

			OrderByList o = new OrderByList(SqlBuilder.DefaultFormatter);
			o.Raw("[c] ASC").Raw("[d] DESC");
			string result = o.GetSql("t");
			string sql = "[c] ASC, [d] DESC";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("OrderBy")]
		public void OrderByTableAlias1()
		{
			SqlBuilder.DefaultFormatter = FormatterLibrary.MsSql;

			OrderByList o = new OrderByList(SqlBuilder.DefaultFormatter);
			o.Raw("[a] ASC");
			o.Ascending("as1");
			o.Descending("ds2");
			o.SetTableAlias("ttt");
			o.Ascending("at1");
			o.SetTableAlias("ddd");
			o.Descending("at2");
			o.SetTableAlias();
			o.Descending("b");

			string result = o.GetSql("t");
			string sql = "[a] ASC, [t].[as1] ASC, [t].[ds2] DESC, [ttt].[at1] ASC, [ddd].[at2] DESC, [t].[b] DESC";
			Assert.AreEqual(sql, result);
		}

		[TestMethod]
		[TestCategory("OrderBy")]
		public void OrderByTableAlias2()
		{
			SqlBuilder.DefaultFormatter = FormatterLibrary.MsSql;

			OrderByList o = new OrderByList(SqlBuilder.DefaultFormatter);
			o.Raw("[a] ASC");
			o.Ascending("as1");
			o.Descending("ds2");
			o.SetTableAlias("ttt");
			o.Ascending("at1");
			o.SetTableAlias("ddd");
			o.Descending("at2");
			o.SetTableAlias();
			o.Descending("b");

			string result = o.GetSql();
			string sql = "[a] ASC, [as1] ASC, [ds2] DESC, [ttt].[at1] ASC, [ddd].[at2] DESC, [b] DESC";
			Assert.AreEqual(sql, result);
		}

	}

}