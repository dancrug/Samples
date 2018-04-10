<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use App\Customer;

class CustomerController extends Controller
{
    /** Display the Table **/
	public function index() {
		$customers = Customer::all();
		return view('customers.index', array('customers' => $customers));
		
	}
	/** Todo: Add individual views **/
    public function show($id) {
	}
	/** Display the form to create a new customer **/
	public function create() {
        return view('customers.create');
	}
	/** Store the data in the DB **/
	public function store(Request $request) {
		 $customer = $this->validate(request(), [
          'first_name' => 'required',
          'last_name' => 'required',
		  'email_address' => 'required'
        ]);
        
        Customer::create($customer);

        return back()->with('success', 'Customer has been added');
	}
	/** Todo: Add edit functionality **/
	public function edit($id)
	{
	    //
	}
	
	/** Todo: Add update functionality **/
	public function update($id)
	{
	    //
	}
	
	/** Todo: Add remove from DB. **/
	public function destroy($id)
	{
	    //
	}
}
