using System;
using Newtonsoft.Json;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Subscription
	/// </summary>
	[Serializable]
	public class PostDonut
	{
		/// <summary>
		/// Запись доступна только платным подписчикам VK Donut.
		/// </summary>
		[JsonProperty("is_don")]
		public bool IsDon { get; set; }

		/// <summary>
		/// Время, в течение которого запись будет доступна только платным подписчикам VK Donut.
		/// </summary>
		[JsonProperty("paid_duration")]
		public int PaidDuration { get; set; }

		/// <summary>
		/// Заглушка для пользователей, которые не оформили подписку VK Donut.
		/// Отображается вместо содержимого записи.
		/// </summary>
		[JsonProperty("placeholder")]
		public string Placeholder { get; set; }

		/// <summary>
		/// Можно ли открыть запись для всех пользователей, а не только подписчиков VK Donut.
		/// </summary>
		[JsonProperty("can_publish_free_copy")]
		public bool CanPublishFreeCopy { get; set; }

		/// <summary>
		/// Информация о том, какие значения VK Donut можно изменить в записи.
		/// Возможные значения:
		///		all — всю информацию о VK Donut.
		///		duration — время, в течение которого запись будет доступна только платным подписчикам VK Donut.
		/// </summary>
		[JsonProperty("edit_mode")]
		public string EditMode { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static PostDonut FromJson(VkResponse response)
		{
			return new PostDonut
			{
				IsDon = response[key: "is_don"],
				PaidDuration = response[key: "paid_duration"],
				Placeholder = response[key: "placeholder"],
				CanPublishFreeCopy = response[key: "can_publish_free_copy"],
				EditMode = response[key: "edit_mode"]
			};
		}
	}
}
