USE [PressfordConsulting]
GO
INSERT [news].[authors] ([Id], [Name]) VALUES (N'67d510fb-cbd3-4c28-96d7-f02ad2fb55dc', N'Alice Smith')
GO
INSERT [news].[authors] ([Id], [Name]) VALUES (N'c1e70893-cedb-4c45-8c4e-ec956d3b2d6f', N'Bob Smith')
GO
SET IDENTITY_INSERT [news].[content] ON 
GO
INSERT [news].[content] ([Id], [Title], [Headline], [Body], [ImageUri]) VALUES (5002, N'Teen has vaccinations after asking Reddit', N'Ethan Lindenberger took to the website to ask whether he could get vaccines without his parents.', N'<div>Ethan Lindenberger from Ohio asked social media site Reddit if he could have vaccines without parental consent.</div><div><br></div><div>His mother would not give her permission, he wrote in the post, which had thousands of reactions.</div><div><br></div><div>He learned he had to wait until he was 18 - which he did, and has now had five vaccinations so far.</div><div><br></div><div>However, he told the BBC his mother still does not agree with his choice, and also apologised for the way he described her online.</div>', N'image')
GO
INSERT [news].[content] ([Id], [Title], [Headline], [Body], [ImageUri]) VALUES (5003, N'Paris to sue Airbnb over ''illegal ads''', N'The fine could amount to €12.5m ($14m, £11m) for the 1,000 ads the city says break French law.', N'<div>The city of Paris is suing Airbnb for €12.5m (£11m) over 1,000 adverts for what it says are illegal rentals.</div><div><br></div><div>Homeowners in the city can rent out their properties for only 120 days per year. They must register themselves as a business and display their registration number on any advertising.</div><div><br></div><div>Under French law, companies can be fined up to €12,500 for each advert.</div><div><br></div><div>Airbnb said the rules in Paris were "inefficient, disproportionate and in contravention of European rules".</div><div><br></div><div>According to a 2018 report by analyst Statista, Paris was Airbnb''s second most popular destination in terms of active rentals, with London in the top spot.</div>', N'2')
GO
INSERT [news].[content] ([Id], [Title], [Headline], [Body], [ImageUri]) VALUES (5004, N'UK economic growth slowest since 2012', N'Declines in construction and car manufacturing contributed to the slowdown, official figures show.', N'<div>The UK economy expanded at its slowest annual rate in six years in 2018 after a sharp contraction in December.</div><div><br></div><div>Growth in the year was 1.4%, down from 1.8% in 2017 and the slowest rate since 2012, the Office for National Statistics (ONS) said.</div><div><br></div><div>The ONS blamed falls in factory output and car production for the slowdown, among other factors.</div><div><br></div><div>It follows forecasts of slower growth in 2019 due to Brexit uncertainty and a weaker global economy.</div><div><br></div><div>According to the ONS, quarterly growth also slowed, falling to 0.2% in the three months to December - down from 0.6% in the three months to September.</div><div><br></div><div>However, Chancellor Philip Hammond said the data showed the economy remained "fundamentally strong" and that he did not foresee a recession.</div>', N'4')
GO
INSERT [news].[content] ([Id], [Title], [Headline], [Body], [ImageUri]) VALUES (5005, N'Insect decline may see ''plague of pests''', N'Houseflies and cockroaches will thrive as bees, butterflies and beetles decline, says a new analysis.', N'<div>A scientific review of insect numbers suggests that 40% of species are undergoing "dramatic rates of decline" around the world.</div><div><br></div><div>The study says that bees, ants and beetles are disappearing eight times faster than mammals, birds or reptiles.</div><div><br></div><div>But researchers say that some species, such as houseflies and cockroaches, are likely to boom.</div><div><br></div><div>The general insect decline is being caused by intensive agriculture, pesticides and climate change.</div><div><br></div>', N'4')
GO
INSERT [news].[content] ([Id], [Title], [Headline], [Body], [ImageUri]) VALUES (6002, N'Will EU roaming charges return after Brexit?', N'Mobile roaming charges: What will happen in Europe after Brexit?', N'<div>In June 2017 the European Union scrapped additional charges for roaming on smartphones when you travel to another EU country.</div><div><br></div><div>Roaming is when you use your mobile phone abroad. Since 2017, UK consumers have, within reason, been able to use the minutes, texts and data included on their mobile phone tariffs when travelling in the EU. The same is true for consumers from other EU countries visiting the UK.</div><div><br></div><div>There are fair use limits, which mean you can use your mobile phone while travelling in another EU country, but you could not get a mobile phone contract from Greece and then&nbsp;</div>', N'1')
GO
SET IDENTITY_INSERT [news].[content] OFF
GO
SET IDENTITY_INSERT [news].[articles] ON 
GO
INSERT [news].[articles] ([Id], [ContentId], [AuthorId], [PublicationDate]) VALUES (5002, 5002, N'c1e70893-cedb-4c45-8c4e-ec956d3b2d6f', CAST(N'2019-02-12T23:03:37.9766667' AS DateTime2))
GO
INSERT [news].[articles] ([Id], [ContentId], [AuthorId], [PublicationDate]) VALUES (5003, 5003, N'c1e70893-cedb-4c45-8c4e-ec956d3b2d6f', CAST(N'2019-02-12T23:03:37.9766667' AS DateTime2))
GO
INSERT [news].[articles] ([Id], [ContentId], [AuthorId], [PublicationDate]) VALUES (5004, 5004, N'c1e70893-cedb-4c45-8c4e-ec956d3b2d6f', CAST(N'2019-02-12T23:03:37.9766667' AS DateTime2))
GO
INSERT [news].[articles] ([Id], [ContentId], [AuthorId], [PublicationDate]) VALUES (5005, 5005, N'c1e70893-cedb-4c45-8c4e-ec956d3b2d6f', CAST(N'2019-02-12T23:03:37.9766667' AS DateTime2))
GO
INSERT [news].[articles] ([Id], [ContentId], [AuthorId], [PublicationDate]) VALUES (6003, 6002, N'c1e70893-cedb-4c45-8c4e-ec956d3b2d6f', CAST(N'2019-02-12T23:03:37.9766667' AS DateTime2))
GO
SET IDENTITY_INSERT [news].[articles] OFF
GO
