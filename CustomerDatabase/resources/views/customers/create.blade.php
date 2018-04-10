<!doctype html>
<html lang="{{ app()->getLocale() }}">
<head>
<meta charset="utf-8">
<meta http-equiv="X-UA-Compatible" content="IE=edge">
<meta name="viewport" content="width=device-width, initial-scale=1">

<title>Customers</title>
<!-- Styles -->
<link href="{{ URL::asset('/css/styles.css') }}" rel="Stylesheet"
	type="text/css" />
</head>
<body>
	<div class="content">
		<h1>Create a customer</h1>
		@if ($errors->any())
		<div class="alert-error">
			<ul>
				@foreach ($errors->all() as $error)
				<li>{{ $error }}</li> @endforeach
			</ul>
		</div>
		@endif @if (\Session::has('success'))
		<div class="alert alert-success">
			<p>{{ \Session::get('success') }}</p>
		</div>
		@endif
		<form method="post" action="{{url('customers')}}">
			{{csrf_field()}}

			<div class="form-group">
				<label for="first_name">First Name</label> <input type="text"
					class="form-control" name="first_name" />
			</div>

			<div class="form-group">
				<label for="last_name">Last Name</label> <input type="text"
					class="form-control" name="last_name" />
			</div>

			<div class="form-group">
				<label for="email_address">Email Address</label> <input type="text"
					class="form-control" name="email_address" />
			</div>
			<button type="submit">Submit</button>
		</form>
		<p>
			<a href="{{ url('/customers') }}">< back</a>
		</p>
	</div>
</body>
</html>
