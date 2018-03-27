<?php
/*
 Custom Settings for WordPress website
 */
?>
<?php
// create custom plugin settings menu
add_action('admin_menu', 'theme_settings_create_menu');

function theme_settings_create_menu() {

	//create new top-level menu
	add_menu_page('Theme Settings', 'Theme Settings', 'administrator', __FILE__, 'theme_settings_page' , 'images/generic.png');

	//call register settings function
	add_action( 'admin_init', 'register_theme_settings' );
}


function register_theme_settings() {
	//register our settings
	register_setting( 'theme-settings-group', 'custom_site_logo' );
	register_setting( 'theme-settings-group', 'customtracking');
	register_setting( 'theme-settings-group', 'custom_google_id');
}

function load_wp_media_files() {
  wp_enqueue_media();
}
add_action( 'admin_enqueue_scripts', 'load_wp_media_files' );

function theme_settings_page() {
?>
<div class="wrap">
	<h2>Custom Settings</h2>
	<form method="post" action="options.php">
		<?php settings_fields('theme-settings-group'); ?>
		<?php do_settings_sections('theme-settings-group'); ?>
		<table class="form-table">
			<!-- Custom Logo Settings -->
			<tr valign="top">
				<th scope="row">Select Custom Logo</th>
				<td>
				<input id="custom_site_logo" name="custom_site_logo" value="<?php echo get_option("custom_site_logo") ?>" type="text" />
				<input id="custom_site_logo_button" class="button" name="custom_site_logo_button" type="text" value="Select" />
				</td>
			</tr>
			<!------>
			<!-- Custom tracking pixels for website --->
			<tr valign="top">
				<th scope="row">Custom Tracking Pixels</th>
				<td><?php $content = get_option("customtracking");
					$editor_id = 'customtracking';
					$settings = array('media_buttons' => false, 'quicktags' => false, 'tinymce' => false);
					wp_editor($content, $editor_id, $settings);
				?></td>
			</tr>
			<!----------->
			<!-- Custom Google Analytics ID for Pixel -->
				<tr valign="top">
					<th scope="row">Enter Google ID</th>
				<td><input type="text" id="custom_google_id" name="custom_google_id" value="<?php echo get_option("custom_google_id"); ?>"></td>
			</tr>
			<!------>
		</table>

		<?php submit_button(); ?>
	</form>
</div>
<script type="text/javascript">
	jQuery(document).ready(function() {
		jQuery('#custom_site_logo_button.button').click(function() {
			wp.media.editor.send.attachment = function(props, attachment) {
				jQuery('#custom_site_logo').val(attachment.url);
			}
			wp.media.editor.open(this);
			return false;
		});
	});
</script>
<?php } ?>
