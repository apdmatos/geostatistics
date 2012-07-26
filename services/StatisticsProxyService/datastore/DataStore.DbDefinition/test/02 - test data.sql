
--------------------------------------------------------------------------------------
------------------------------ Indicadores  ------------------------------------------
--------------------------------------------------------------------------------------

-- provider
INSERT INTO config.provider(name, nameAbbr, serviceURL, URL)
	VALUES(
		'Instituto Nacional de Estatística',
		'INE',
		'http://localhost:42136/INEStatisticsProvider.svc',
		'http://www.ine.pt'
	);

-- temas
INSERT INTO config.theme(provider_id, name, nameAbbr) 
	VALUES(
		1,
		'Território', 
		'Território'
	);
	
-- sub temas
INSERT INTO config.subtheme(theme_id, provider_id, name, nameAbbr) 
	VALUES(
		1,
		1,
		'Ordenamento do território', 
		'Ordenamento do território'
	);

-- indicadores ine
INSERT INTO config.indicator(provider_id, sourceid, name, nameAbbr, theme_id, subtheme_id)
	VALUES(
		1,
		'0000009',
		'Densidade populacional (N.º/ km²) por Local de residência; Anual',
		'Densidade populacional (N.º/ km²)',
		1, 
		1
	);


INSERT INTO config.configuration(geolevel, shapefile_id) VALUES ('NUTS1', 4);
INSERT INTO config.indicator_configuration(indicator_id, configuration_id) VALUES(1, 1);

INSERT INTO config.configuration(geolevel, shapefile_id) VALUES ('NUTS2', 5);
INSERT INTO config.indicator_configuration(indicator_id, configuration_id) VALUES(1, 2);

INSERT INTO config.configuration(geolevel, shapefile_id) VALUES ('NUTS3', 6);
INSERT INTO config.indicator_configuration(indicator_id, configuration_id) VALUES(1, 3);

INSERT INTO config.configuration(geolevel, shapefile_id) VALUES ('Municipality', 2);
INSERT INTO config.indicator_configuration(indicator_id, configuration_id) VALUES(1, 4);

INSERT INTO config.configuration(geolevel, shapefile_id) VALUES ('Parish', 3);
INSERT INTO config.indicator_configuration(indicator_id, configuration_id) VALUES(1, 5);