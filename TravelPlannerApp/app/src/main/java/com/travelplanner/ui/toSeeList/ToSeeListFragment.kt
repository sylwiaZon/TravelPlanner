package com.travelplanner.ui.toSeeList

import android.content.Intent
import android.os.Bundle
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.LinearLayout
import androidx.fragment.app.Fragment
import androidx.lifecycle.Observer
import androidx.lifecycle.ViewModelProvider
import androidx.recyclerview.widget.LinearLayoutManager
import androidx.recyclerview.widget.RecyclerView
import com.google.android.material.button.MaterialButton
import com.travelplanner.R
import com.travelplanner.ui.localHighlights.LocalHighlightsActivity
import com.travelplanner.ui.localHighlights.LocalHighlightsAdapter
import com.travelplanner.ui.localHighlights.LocalHighlightsFragment
import com.travelplanner.ui.poi.PoiActivity
import com.travelplanner.ui.poi.PoiFragment

class ToSeeListFragment : Fragment() {

    lateinit var viewModel: ToSeeListViewModel

    override fun onCreateView(inflater: LayoutInflater, container: ViewGroup?, savedInstanceState: Bundle?): View? {
        val v = inflater.inflate(R.layout.fragment_to_see_list, container, false)
        viewModel =
                ViewModelProvider(this).get(ToSeeListViewModel::class.java)
        activity?.intent?.getStringExtra(EXTRA_TRAVEL_ID)?.let {
            viewModel.setTravelId(it)
        }
        val noData = v.findViewById<LinearLayout>(R.id.no_saved_to_see)
        val button = v.findViewById<MaterialButton>(R.id.to_see_button)
        val recycler = v.findViewById<RecyclerView>(R.id.to_see_list_recycler)
        val adapter = ToSeeListAdapter()
        recycler.adapter = adapter
        recycler.layoutManager = LinearLayoutManager(context)
        viewModel.toSeeList.observe(viewLifecycleOwner, Observer {
            if(it.isNotEmpty()){
                noData.visibility = View.GONE
                recycler.visibility = View.VISIBLE
                adapter.setData(it)
            } else {
                noData.visibility = View.VISIBLE
                recycler.visibility = View.GONE
                button.setOnClickListener {
                    val intent = Intent(context, LocalHighlightsActivity::class.java)
                    intent.putExtra(LocalHighlightsFragment.EXTRA_TRAVEL_ID, activity?.intent?.getStringExtra(EXTRA_TRAVEL_ID))
                    context?.startActivity(intent)
                }
            }
        })

        return v
    }

    companion object {
        val EXTRA_TRAVEL_ID = "travel_id"
    }
}