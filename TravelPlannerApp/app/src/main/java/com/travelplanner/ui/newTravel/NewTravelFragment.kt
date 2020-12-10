package com.travelplanner.ui.newTravel

import android.os.Bundle
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.Button
import android.widget.EditText
import android.widget.TextView
import androidx.fragment.app.Fragment
import androidx.lifecycle.Observer
import androidx.lifecycle.ViewModelProvider
import com.travelplanner.R

class NewTravelFragment : Fragment() {

    private lateinit var newTravelViewModel: NewTravelViewModel

    override fun onCreateView(
            inflater: LayoutInflater,
            container: ViewGroup?,
            savedInstanceState: Bundle?
    ): View? {
        newTravelViewModel =
                ViewModelProvider(this).get(NewTravelViewModel::class.java)
        val root = inflater.inflate(R.layout.fragment_new_travel, container, false)
        val locationInput = root.findViewById<EditText>(R.id.new_travel_location)
        val searchLocationButton = root.findViewById<Button>(R.id.new_travel_location_search_button)
        val changeLocationButton = root.findViewById<Button>(R.id.new_travel_location_change_button)
        val startDate = root.findViewById<EditText>(R.id.create_travel_start_date)
        val endDate = root.findViewById<EditText>(R.id.create_travel_end_date)
        val adultsNumber = root.findViewById<EditText>(R.id.create_travel_adults)
        val childrenNumber = root.findViewById<EditText>(R.id.create_travel_children)
        val childrenAges = root.findViewById<EditText>(R.id.create_travel_children_ages)
        val addTravelButton = root.findViewById<Button>(R.id.create_travel_add_travel_button)

        return root
    }
}