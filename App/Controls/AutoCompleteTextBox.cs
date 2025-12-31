using DataCommon.Models.Abstractions;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MOM.Controls;

internal class AutoCompleteTextBox : TextBox
{
	public AutoCompleteTextBox()
	{
		PreviewKeyDown += (s, e) =>
		{
			if (e.KeyCode == Keys.Tab || e.KeyCode == Keys.Enter)
			{
				FixCasing();
			}
		};
	}

	public async Task SetSuggestionsWhereActiveAsync<T>(IQueryable<T> source, Expression<Func<T, string?>> selector) where T : AuditableEntity
	{
		await SetSuggestionsAsync(source, e => e.Active, selector);
	}

	public async Task SetSuggestionsAsync<T>(IQueryable<T> source, Expression<Func<T, bool>> predicate, Expression<Func<T, string?>> selector) where T : class
	{
		var materialized = await source
			.Where(predicate)
			.Select(selector)
			.Where(value => value != null && value != string.Empty)
			.Distinct()
			.ToListAsync();
		var items = materialized
			.Where(value => !string.IsNullOrWhiteSpace(value))
			.Select(value => value!.Trim())
			.Distinct(StringComparer.OrdinalIgnoreCase)
			.OrderBy(value => value);
		SetSuggestions(items);
	}

	public void SetSuggestions(IEnumerable<string> items)
	{
		AutoCompleteCustomSource = [.. items];
		AutoCompleteSource = AutoCompleteSource.CustomSource;
		if (AutoCompleteMode == AutoCompleteMode.None)
		{
			AutoCompleteMode = AutoCompleteMode.SuggestAppend;
		}
	}

	private void FixCasing()
	{
		if (AutoCompleteCustomSource is not null)
		{
			var match = AutoCompleteCustomSource
				.Cast<string>()
				.FirstOrDefault(item => string.Equals(item, Text, StringComparison.OrdinalIgnoreCase));

			if (!string.IsNullOrWhiteSpace(match))
			{
				Text = match;
				SelectionStart = Text.Length;
			}
		}
	}
}
