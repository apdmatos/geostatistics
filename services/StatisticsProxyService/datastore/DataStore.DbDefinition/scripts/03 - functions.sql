

create or replace function config.getconfigurations( p_indicatorId integer, p_geolevel text)
returns SETOF config.configurationview
AS $$
declare
	ret_row record;
BEGIN
	if p_geolevel is not null then
		FOR ret_row in select cv.configuration_id, cv.configuration_geolevel, cv.shapefile_id, 
					cv.shapefile_name, cv.shapefile_path, cv.shapefile_filename, cv.shapefile_level
			from config.configurationview as cv join config.indicator_configuration as ic
			on(cv.configuration_id = ic.configuration_id)
			where ic.indicator_id = p_indicatorId and cv.configuration_geolevel = p_geolevel
		loop
			return next ret_row;
		end loop;
	else	
		FOR ret_row in select cv.configuration_id, cv.configuration_geolevel, cv.shapefile_id, 
					cv.shapefile_name, cv.shapefile_path, cv.shapefile_filename, cv.shapefile_level
			from config.configurationview as cv join config.indicator_configuration as ic
			on(cv.configuration_id = ic.configuration_id)
			where ic.indicator_id = p_indicatorId
		loop
			return next ret_row;
		end loop;
	end if;
	return;
END;
$$ LANGUAGE 'plpgsql';

---------------------------------------------------
-- test
--select * from config.getconfigurations(1, 'NUTS1');
--select * from config.getconfigurations(1, null);


create or replace function config.getShapefileConfigurarionURL( p_indicatorId integer, p_geolevel text)
returns text
AS $$
BEGIN
	return (select cv.shapefile_path || E'\\' || cv.shapefile_filename
	from config.configurationview as cv join config.indicator_configuration as ic
	on(cv.configuration_id = ic.configuration_id)
	where ic.indicator_id = p_indicatorId and cv.configuration_geolevel = p_geolevel);

	
END;
$$ LANGUAGE 'plpgsql';

---------------------------------------------------
--test
--select config.getShapefileConfigurarionURL(1, 'NUTS1')




create or replace function config.getIndicatorsByProviderId( p_providerId integer, p_page int, p_recordsPerPage int)
returns SETOF config.indicatorview
AS $$
declare 
	v_offset integer;
	ret_row record;
BEGIN

	if p_page is not null and p_recordsPerPage is not null then
	begin
		v_offset:= (p_page - 1) * p_recordsPerPage;
		FOR ret_row in SELECT provider_id, provider_name, provider_nameabbr, provider_serviceurl, 
					provider_url, indicator_id, indicator_sourceid, indicator_name, 
					indicator_nameabbr, indicator_themeid, indicator_subthemeid
				FROM config.indicatorview
				where provider_id = p_providerId
				offset v_offset
				limit p_recordsPerPage
		loop
			RETURN NEXT ret_row;
		end loop;
	end;
	else
		FOR ret_row in SELECT provider_id, provider_name, provider_nameabbr, provider_serviceurl, 
					provider_url, indicator_id, indicator_sourceid, indicator_name, 
					indicator_nameabbr, indicator_themeid, indicator_subthemeid
				FROM config.indicatorview
				where provider_id = p_providerId
		loop
			RETURN NEXT ret_row;
		end loop;
	end if;
	
	RETURN;
END;
$$ LANGUAGE 'plpgsql';


---------------------------------------------------
--test
--select * from config.getIndicatorsByProviderId(1, 1, 3)





create or replace function config.getIndicatorsBySubThemeId( p_providerId integer, p_themeId int, p_subthemeId int, p_page int, p_recordsPerPage int)
returns SETOF config.indicatorview
AS $$
declare 
	v_offset integer;
	ret_row record;
BEGIN

	if p_page is not null and p_recordsPerPage is not null then
	begin
		v_offset:= (p_page - 1) * p_recordsPerPage;
		FOR ret_row in SELECT provider_id, provider_name, provider_nameabbr, provider_serviceurl, 
					provider_url, indicator_id, indicator_sourceid, indicator_name, 
					indicator_nameabbr, indicator_themeid, indicator_subthemeid
				FROM config.indicatorview
				where provider_id = p_providerId and indicator_themeid = p_themeId and indicator_subthemeid = p_subthemeId
				offset v_offset
				limit p_recordsPerPage
		loop
			RETURN NEXT ret_row;
		end loop;
	end;
	else
		FOR ret_row in SELECT provider_id, provider_name, provider_nameabbr, provider_serviceurl, 
					provider_url, indicator_id, indicator_sourceid, indicator_name, 
					indicator_nameabbr, indicator_theme_id, indicator_subthemeid
				FROM config.indicatorview
				where provider_id = p_providerId and indicator_themeid = p_themeId and indicator_subthemeid = p_subthemeId
		loop
			RETURN NEXT ret_row;
		end loop;
	end if;
	
	RETURN;
END;
$$ LANGUAGE 'plpgsql';


---------------------------------------------------
--test
--select * from config.getIndicatorsBySubThemeId(1, 1, 1, 1, 1)



create or replace function config.getProviders(p_page int, p_recordsPerPage int)
returns SETOF config.providerview
AS $$
declare 
	v_offset integer;
	ret_row record;
BEGIN

	if p_page is not null and p_recordsPerPage is not null then
	begin
		v_offset:= (p_page - 1) * p_recordsPerPage;
		FOR ret_row in SELECT provider_id, provider_name, provider_nameabbr, provider_serviceurl, provider_url
				FROM config.providerview
				offset v_offset
				limit p_recordsPerPage
		loop
			RETURN NEXT ret_row;
		end loop;
	end;
	else
		FOR ret_row in SELECT provider_id, provider_name, provider_nameabbr, provider_serviceurl, provider_url
				FROM config.providerview
		loop
			RETURN NEXT ret_row;
		end loop;
	end if;
	
	RETURN;
END;
$$ LANGUAGE 'plpgsql';

---------------------------------------------------
--test
--select * from config.getProviders(1, 1)



create or replace function config.getShapefiles(p_shapefilegroupId int, p_page int, p_recordsPerPage int)
returns SETOF config.shapefileview
AS $$
declare 
	v_offset integer;
	ret_row record;
	query text;
BEGIN

	query:= 'SELECT shapefile_id, shapefile_name, shapefile_path, shapefile_filename, 
			shapefile_level, shapefilegroup_id, shapefilegroup_name
		 FROM config.shapefileview';

	if p_shapefilegroupid is not null then
		query:= query || ' where shapefilegroup_id=' || p_shapefilegroupId;
	end if;
	

	if p_page is not null and p_recordsPerPage is not null then
	begin
		v_offset:= (p_page - 1) * p_recordsPerPage;
		query:= query || ' offset ' || v_offset || ' limit ' || p_recordsPerPage;
	end;
	end if;


	FOR ret_row in EXECUTE query
	loop
		RETURN NEXT ret_row;
	end loop;
	
	RETURN;
END;
$$ LANGUAGE 'plpgsql';


---------------------------------------------------
--test
--select * from config.getShapefiles(null, null, null)
--select * from config.getShapefiles(1, 1, 1)


create or replace function config.getshapefilegroups(p_page int, p_recordsPerPage int)
returns SETOF config.shapefilegroupview
AS $$
declare 
	v_offset integer;
	ret_row record;
BEGIN

	if p_page is not null and p_recordsPerPage is not null then
	begin
		v_offset:= (p_page - 1) * p_recordsPerPage;
		FOR ret_row in SELECT shapefilegroup_id, shapefilegroup_name
				FROM config.shapefilegroupview
				offset v_offset
				limit p_recordsPerPage
		loop
			RETURN NEXT ret_row;
		end loop;
	end;
	else
		FOR ret_row in SELECT shapefilegroup_id, shapefilegroup_name
				FROM config.shapefilegroupview
		loop
			RETURN NEXT ret_row;
		end loop;
	end if;
	
	RETURN;
END;
$$ LANGUAGE 'plpgsql';

---------------------------------------------------
--test
--select * from config.getshapefilegroups(1, 1)
--select * from config.getshapefilegroups(null, null)

