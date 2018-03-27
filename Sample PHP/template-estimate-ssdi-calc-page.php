<?php
/*
 Template Name: Page : SSDI Calc Template
 Custom Page template for WordPress
 */
?>
<?php get_header(); ?>
<style type="text/css">
	.calc {
		margin: 15px 0 0 0;
		display: none;
		width: 100%;
		max-width: 500px;
	}
	.calc .field {
		float: none;
		width: 100%;
		min-height: 75px;
	}
	.calc .field label {
		font-size: 1.6em;
	}
	.calc .field select {
		font-size: 1.4em;
		padding: 5px;
	}
	.calc .field input {
		font-size: 1.4em;
		padding: 10px 20px;
	}
	.calc h2#total {
		color: green;
	}
 </style>
<script>
	var genderageval = 0,
	    stateval = 0,
	    medconditionval = 0,
	    total = 0,
	    ageLength = 0;
	jQuery(document).ready(function() {
		if (jQuery("#calc")) {
			jQuery(".calc").show();
			jQuery("#calc").append(jQuery(".calc"));
			jQuery("#gender").change(function() {
				var gVal = jQuery(this).val();
				var maleVals = {
					"Select Age*" : "0",
					"0-24" : "631.34",
					"25-29" : "900.27",
					"30-34" : "1045.35",
					"35-39" : "1155.75",
					"40-44" : "1250.59",
					"45-49" : "1325.57",
					"50-54" : "1393.32",
					"55-59" : "1510.56",
					"60-64" : "1609.21",
					"65+" : "1594.29"
				};
				var femaleVals = {
					"Select Age*" : "0",
					"0-24" : "621.27",
					"25-29" : "844.84",
					"30-34" : "960.97",
					"35-39" : "1023.20",
					"40-44" : "1052.24",
					"45-49" : "1080.30",
					"50-54" : "1090.22",
					"55-59" : "1151.03",
					"60-64" : "1221.73",
					"65+" : "1233.13"
				};
				jQuery("#cage").empty();
				if (gVal == "male") {
					jQuery.each(maleVals, function(value, key) {
						jQuery('#cage').append(jQuery('<option>', {
							value : key
						}).text(value));
					});
					ageLength = maleVals.length;
				} else if (gVal == "female") {
					jQuery.each(femaleVals, function(value, key) {
						jQuery('#cage').append(jQuery('<option>', {
							value : key
						}).text(value));
					});
					ageLength = femaleVals.length;
				}
				jQuery("#cage").change(function() {
					genderageval = parseFloat(jQuery(this).val());
				});
			});

			jQuery("#state").change(function() {
				stateval = parseFloat(jQuery(this).val());
			});
			jQuery("#medical-condition").change(function() {
				medconditionval = parseFloat(jQuery(this).val());
			})
			jQuery("#btnsubmit").click(function() {
				var errorCount = 0,
				    errorMessage = "";
				if (genderageval == 0) {
					errorMessage += "Please Select Age/Gender\n";
					errorCount += 1;
				}
				if (stateval == 0) {
					errorMessage += "Please Select State\n";
					errorCount += 1;
				}
				if (medconditionval == 0) {
					errorMessage += "Please Select Medical Condition\n";
					errorCount += 1;
				}
				if (errorCount == 0) {
					total = ((genderageval + stateval + medconditionval) / 3).toFixed(2);
					jQuery(".field #total").text("$" + total.replace(/(\d)(?=(\d\d\d)+(?!\d))/g, "$1,"));
					return true;
				} else {
					alert(errorMessage);
				}
			});
			jQuery("#cage").click(function() {
				if (ageLength == 0) {
					alert("Please Select Gender");
				}
			});
		}
	});
	</script>
<div class="main-wrapper-item">
	<?php if(have_posts()) : ?>
	<?php while(have_posts()) : the_post(); ?>

	<!-- BreadCrumb Section // -->
<div class="bread-title-holder">
	<div class="container">
		<div class="row-fluid">
			<div class="container_inner clearfix">
				<h1 class="title"><?php the_title(); ?></h1>
				<?php
				if ((class_exists('instaapp_breadcrumb_class'))) {$instaapp_breadcumb -> custom_breadcrumb();
				}
				?>
			</div>
		</div>
	</div>
</div>
<!-- \\ BreadCrumb Section -->
	<div class="page-content default-pagetemp">
		<div class="container post-wrap">
			<div class="row-fluid">
				<div id="content" class="span7">
					<div class="post" id="post-<?php the_ID(); ?>">
						<div class="skepost clearfix">
							<?php the_content(); ?>
							<?php wp_link_pages(array('before' => '<p><strong>' . __('Pages :', 'instaappointment-lite') . '</strong>', 'after' => '</p>', __('number', 'instaappointment-lite'), )); ?>
						</div>
					<!-- skepost -->
					<?php edit_post_link(__('Edit', 'instaappointment-lite'), '', ''); ?>
					<?php
					if (comments_open() || get_comments_number()) {
						comments_template();
					}
				?>
					</div>
					<!-- post -->
					<!-- calc -->
					<div class="calc">
						<div class="field" data-step="1">
							<select id="gender" class="select">
								<option value="0">Select Gender: *</option>
								<option value="male">Male</option>
								<option value="female">Female</option>
							</select>
							</div>
							<div class="field" data-step="2">
								<select id="cage">
									<option>Select Age: *</option>
								</select>
							</div>
							<div class="field" data-step="3">
								<select id="state">
									<option value="1145.98">Alabama</option>
									<option value="1147.96">Alaska</option>
									<option value="1208.44">Arizona</option>
									<option value="1110.11">Arkansas</option>
									<option value="1196.73">California</option>
									<option value="1181.95">Colorado</option>
									<option value="1211.91">Connecticut</option>
									<option value="1238.28">Delaware</option>
									<option value="1030.99">District of Columbia</option>
									<option value="1177.19">Florida</option>
									<option value="1168.51">Georgia</option>
									<option value="1193.02">Hawaii</option>
									<option value="1136.85">Idaho</option>
									<option value="1187.85">Illinois</option>
									<option value="1173.60">Indiana</option>
									<option value="1108.99">Iowa</option>
									<option value="1139.74">Kansas</option>
									<option value="1138.46">Kentucky</option>
									<option value="1125.90">Louisiana</option>
									<option value="1085.09">Maine</option>
									<option value="1205.46">Maryland</option>
									<option value="1163.11">Massachusetts</option>
									<option value="1215.29">Michigan</option>
									<option value="1156.84">Minnesota</option>
									<option value="1112.89">Mississippi</option>
									<option value="1136.23">Missouri</option>
									<option value="1101.51">Montana</option>
									<option value="1101.93">Nebraska</option>
									<option value="1227.93">Nevada</option>
									<option value="1191.70">New Hampshire</option>
									<option value="1279.54">New Jersey</option>
									<option value="1109.26">New Mexico</option>
									<option value="1199.82">New York</option>
									<option value="1164.83">North Carolina</option>
									<option value="1079.52">North Dakota</option>
									<option value="1126.46">Ohio</option>
									<option value="1121.83">Oklahoma</option>
									<option value="1163.87">Oregon</option>
									<option value="1168.43">Pennsylvania</option>
									<option value="1135.13">Rhode Island</option>
									<option value="1182.88">South Carolina</option>
									<option value="1081.92">South Dakota</option>
									<option value="1136.63">Tennessee</option>
									<option value="1144.21">Texas</option>
									<option value="1161.76">Utah</option>
									<option value="1096.79">Vermont</option>
									<option value="1173.44">Virginia</option>
									<option value="1179.81">Washington</option>
									<option value="1181.83">West Virginia</option>
									<option value="1159.15">Wisconsin</option>
									<option value="1158.77">Wyoming</option>
								</select>
							</div>
							<div class="field" data-step="4">
								<select id="medical-condition">
									<option value="0">Select Medical Condition: *</option>
									<option value="850.49">Congenital anomalies</option>
									<option value="1113.85">Endocrine, nutritional, and metabolic diseases</option>
									<option value="1123.16">Infectious and parasitic diseases</option>
									<option value="1181.23">Injuries</option>
									<option value="758.84">Autistic disorders</option>
									<option value="749.17">Developmental disorders</option>
									<option value="734.93">Childhood and adolescent disorders not elsewhere classified</option>
									<option value="734.02">Intellectual disability</option>
									<option value="1052.57">Mood disorders</option>
									<option value="1112.72">Organic mental disorders</option>
									<option value="883.84">Schizophrenic and other psychotic disorders</option>
									<option value="1009.76">Other Mental Disorders</option>
									<option value="1318.58">Neoplasms</option>
									<option value="1033.51">Blood and blood-forming organs</option>
									<option value="1279.21">Circulatory system</option>
									<option value="1221.15">Digestive system</option>
									<option value="1211.05">Genitourinary system</option>
									<option value="1227.07">Musculoskeletal system and connective tissue</option>
									<option value="1155.98">Nervous system and sense organs</option>
									<option value="1167.98">Respiratory system</option>
									<option value="1113.47">Skin and subcutaneous tissue</option>
									<option value="1193.51">Other Diseases</option>
									<option value="957.47">Unknown</option>
								</select>
							</div>
							<div class="field" data-step="5"><input type="button" id="btnsubmit" value="Submit"/></div>
							<div class="field" data-step="6">
								<h2><strong>Average Benefit</strong></h2><h2 id="total"></h2>
							</div>
					</div>
					<!-- calc-->
					<?php endwhile; ?>
					<?php else : ?>
						<div class="post">
							<h2><?php _e('Page Does Not Exist', 'instaappointment-lite'); ?></h2>
						</div>
					<?php endif; ?>
						<div class="clearfix"></div>
				</div>
				<!-- content -->
				<!-- Sidebar -->
				<div id="sidebar" class="span5">
					<?php get_sidebar('page'); ?>
				</div>
				<div class="clearfix"></div>
				<!-- Sidebar -->
			</div>
		</div>
	</div>
</div>
<?php get_footer()?>
