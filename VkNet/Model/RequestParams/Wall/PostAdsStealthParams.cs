﻿using System.Collections.Generic;
using Newtonsoft.Json;
using VkNet.Model.Attachments;
using VkNet.Utils;

namespace VkNet.Model.RequestParams
{
    /// <summary>
    /// параметры запроса wall.PostAdsStealth
    /// </summary>
    public class PostAdsStealthParams
    {
        /// <summary>
        /// идентификатор владельца стены (идентификатор сообщества нужно указывать со знаком «минус»). 
        /// </summary>
        [JsonProperty("owner_id")]
        public long OwnerId { get; set; }
        
        /// <summary>
        /// текст записи
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; }
        
        /// <summary>
        /// список объектов, приложенных к записи и разделённых символом ",".
        /// </summary>
        [JsonProperty("attachments")]
        public IEnumerable<MediaAttachment> Attachments { get; set; }
        
        /// <summary>
        /// 1 — у записи, размещенной от имени сообщества, будет добавлена подпись (имя пользователя, разместившего запись),
        /// 0 — без подписи. 
        /// </summary>
        [JsonProperty("signed")]
        public bool? Signed { get; set; }
        
        /// <summary>
        /// географическая широта отметки, заданная в градусах (от -90 до 90)
        /// </summary>
        [JsonProperty("lat")]
        public double Lat { get; set; }
        
        /// <summary>
        /// географическая долгота отметки, заданная в градусах (от -180 до 180).
        /// </summary>
        [JsonProperty("long")]
        public double Long { get; set; }
        
        /// <summary>
        /// идентификатор места.
        /// </summary>
        [JsonProperty("place_id")]
        public ulong PlaceId { get; set; }
        
        /// <summary>
        /// уникальный идентификатор, предназначенный для предотвращения повторной отправки одинаковой записи. 
        /// </summary>
        [JsonProperty("guid")]
        public string Guid { get; set; }
        
        /// <summary>
        /// идентификатор кнопки, которую необходимо добавить к сниппету для ссылки. 
        /// </summary>
        [JsonProperty("link_button")]
        public LinkButton LinkButton { get; set; }
        
        /// <summary>
        /// заголовок, который должен быть использован для сниппета.
        /// Если не указан, будет автоматически получен с целевой ссылки.
        /// Обязательно указывать в случае, если ссылка является номером телефона. 
        /// </summary>
        [JsonProperty("link_title")]
        public string LinkTitle { get; set; }
        
        /// <summary>
        /// ссылка на изображение, которое должно быть использовано для сниппета.
        /// Минимальное разрешение: 537x240.
        /// Если не указана, будет автоматически загружена с целевой ссылки.
        /// Обязательно указывать в случае, если ссылка является номером телефона. 
        /// </summary>
        [JsonProperty("link_image")]
        public string LinkImage { get; set; }
        
        /// <summary>
        /// Привести к типу VkParameters.
        /// </summary>
        /// <param name="p">Параметры.</param>
        /// <returns></returns>		
        public static VkParameters ToVkParameters(PostAdsStealthParams p)
        {
            var parameters = new VkParameters
            {
                { "owner_id", p.OwnerId },
                { "message", p.Message },
                { "attachments", p.Attachments },
                { "signed", p.Signed },
                { "lat", p.Lat },
                { "long", p.Long },
                { "place_id", p.PlaceId },
                {"link_title", p.LinkTitle},
                {"link_image", p.LinkImage},
                {"guid", p.Guid},
                {"link_button", p.LinkButton}
            };

            return parameters;
        }
    }
}