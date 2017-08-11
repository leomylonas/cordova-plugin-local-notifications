﻿/*
 * Apache 2.0 License
 *
 * Copyright (c) Sebastian Katzer 2017
 *
 * This file contains Original Code and/or Modifications of Original Code
 * as defined in and that are subject to the Apache License
 * Version 2.0 (the 'License'). You may not use this file except in
 * compliance with the License. Please obtain a copy of the License at
 * http://opensource.org/licenses/Apache-2.0/ and read it before using this
 * file.
 *
 * The Original Code and all software distributed under the License are
 * distributed on an 'AS IS' basis, WITHOUT WARRANTY OF ANY KIND, EITHER
 * EXPRESS OR IMPLIED, AND APPLE HEREBY DISCLAIMS ALL SUCH WARRANTIES,
 * INCLUDING WITHOUT LIMITATION, ANY WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE, QUIET ENJOYMENT OR NON-INFRINGEMENT.
 * Please see the License for the specific language governing rights and
 * limitations under the License.
 */

namespace LocalNotificationProxy.LocalNotification
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Toolkit.Uwp.Notifications;
    using Windows.Data.Xml.Dom;

    public sealed class Options
    {
        /// <summary>
        /// Gets or sets notification ID.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets notification title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets notification text.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Gets or sets app badge number.
        /// </summary>
        public int Badge { get; set; }

        /// <summary>
        /// Gets or sets the notification sound.
        /// </summary>
        public string Sound { get; set; }

        /// <summary>
        /// Gets or sets the notification image.
        /// </summary>
        public string Image { get; set; }

        /// <summary>
        /// Gets or sets the notification fire date.
        /// </summary>
        public long At { get; set; }

        /// <summary>
        /// Gets or sets the notification repeat interval.
        /// </summary>
        public string Every { get; set; }

        /// <summary>
        /// Gets or sets the notification user data.
        /// </summary>
        public string Data { get; set; }

        /// <summary>
        /// Gets or sets the notification attachments.
        /// </summary>
        public string[] Attachments { get; set; }

        /// <summary>
        /// Gets or sets the notification buttons.
        /// </summary>
        public Button[] Buttons { get; set; }

        /// <summary>
        /// Deserializes the XML string into an instance of Options.
        /// </summary>
        /// <param name="identifier">The serialized instance of Options as an xml string.</param>
        /// <returns>An instance where all properties have been assigned.</returns>
        public static Options Parse(string identifier)
        {
            var doc = new XmlDocument();
            doc.LoadXml(identifier);

            var options = new Options();
            var node = doc.DocumentElement;

            options.ID = int.Parse(node.GetAttribute("id"));
            options.Badge = int.Parse(node.GetAttribute("badge"));
            options.At = int.Parse(node.GetAttribute("at"));

            if (node.GetAttributeNode("text") != null)
            {
                options.Text = node.GetAttribute("text");
            }

            if (node.GetAttributeNode("title") != null)
            {
                options.Title = node.GetAttribute("title");
            }

            if (node.GetAttributeNode("sound") != null)
            {
                options.Sound = node.GetAttribute("sound");
            }

            if (node.GetAttributeNode("image") != null)
            {
                options.Image = node.GetAttribute("image");
            }

            if (node.GetAttributeNode("every") != null)
            {
                options.Every = node.GetAttribute("every");
            }

            if (node.GetAttributeNode("data") != null)
            {
                options.Data = node.GetAttribute("data");
            }

            return options;
        }

        /// <summary>
        /// Gets the instance as an serialized xml element.
        /// </summary>
        /// <returns>Element with all property values set as attributes.</returns>
        public string GetXml()
        {
            var node = new XmlDocument().CreateElement("options");

            node.SetAttribute("id", this.ID.ToString());
            node.SetAttribute("badge", this.Badge.ToString());
            node.SetAttribute("at", this.At.ToString());

            if (this.Title != null)
            {
                node.SetAttribute("title", this.Title);
            }

            if (this.Text != null)
            {
                node.SetAttribute("text", this.Text);
            }

            if (this.Sound != null)
            {
                node.SetAttribute("sound", this.Sound);
            }

            if (this.Image != null)
            {
                node.SetAttribute("image", this.Image);
            }

            if (this.Every != null)
            {
                node.SetAttribute("every", this.Every);
            }

            if (this.Data != null)
            {
                node.SetAttribute("data", this.Data);
            }

            return node.GetXml();
        }
    }
}